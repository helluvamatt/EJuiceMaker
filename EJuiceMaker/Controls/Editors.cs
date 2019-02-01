using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms.Design;
using R = EJuiceMaker.Properties.Resources;

namespace EJuiceMaker.Controls
{
    #region Converters

    internal class YesNoConverter : BooleanConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is bool && destinationType == typeof(string))
            {
                return values[(bool)value ? 1 : 0];
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string txt = value as string;
            if (values[0] == txt) return false;
            if (values[1] == txt) return true;
            return base.ConvertFrom(context, culture, value);
        }

        private static readonly string[] values = new string[] { R.No, R.Yes };
    }

    internal class FirstLineConverter : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is string multilineStr)
            {
                var lines = multilineStr.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                return lines?[0];
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    internal class CurrencyConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                var val = (decimal)value;
                return val.ToString("C", culture);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string val)
            {
                if (string.IsNullOrEmpty(val)) return 0.0m;
                if (decimal.TryParse(val, NumberStyles.Currency, culture, out decimal result)) return result;
                throw new FormatException(R.ErrorFormatCurrency);
            }
            return base.ConvertFrom(context, culture, value);
        }
    }

    internal class PercentConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                var val = (float)value;
                return val.ToString("P", culture);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string val)
            {
                if (string.IsNullOrEmpty(val)) return 0.0f;
                val = val.Replace(culture.NumberFormat.PercentSymbol, "");
                if (float.TryParse(val, NumberStyles.Number, culture, out float result)) return result / 100f;
                throw new FormatException(R.ErrorFormatPercent);
            }
            return base.ConvertFrom(context, culture, value);
        }
    }

    internal class EnumConverterEx : EnumConverter
    {
        private readonly Type enumType;

        public EnumConverterEx(Type type) : base(type)
        {
            enumType = type;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            return destType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
        {
            var fi = enumType.GetField(Enum.GetName(enumType, value));
            return R.ResourceManager.GetString($"Description_{enumType.Name}_{fi.Name}") ?? value.ToString();
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type srcType)
        {
            return srcType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            foreach (FieldInfo fi in enumType.GetFields())
            {
                // L10n Note: Don't use the same description text for two enum values
                var desc = R.ResourceManager.GetString($"Description_{enumType.Name}_{fi.Name}");
                if (desc != null && desc == (string)value) return Enum.Parse(enumType, fi.Name);
            }
            return Enum.Parse(enumType, (string)value);
        }
    }

    #endregion

    #region Editors

    internal class DateTimeEditor : UITypeEditor
    {
        private readonly DateTimePickerEx _Picker;

        public DateTimeEditor()
        {
            _Picker = new DateTimePickerEx();
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var current = (DateTime?)value;
            if (provider != null)
            {
                if (provider.GetService(typeof(IWindowsFormsEditorService)) is IWindowsFormsEditorService editorService)
                {
                    _Picker.Checked = current.HasValue;
                    _Picker.Value = current.HasValue ? current.Value : DateTime.Now;
                    editorService.DropDownControl(_Picker);
                    if (_Picker.Checked) current = _Picker.Value;
                    else current = null;
                }
            }
            return current;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
    }

    #endregion
}
