using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EJuiceMaker.Controls
{
    internal class UnitNumericUpDown : NumericUpDown
    {
        protected override void UpdateEditText()
        {
            if (!string.IsNullOrEmpty(Unit)) Text = Value + " " + Unit;
            else base.UpdateEditText();
        }

        protected override void ValidateEditText()
        {
            if (!string.IsNullOrEmpty(Unit))
            {
                // Copied from referencesource: ParseEditText
                try
                {
                    if (!string.IsNullOrEmpty(Text) && !(Text.Length == 1 && Text == "-"))
                    {
                        var text = Text.Substring(0, Text.Length - Unit.Length - 1);
                        if (Hexadecimal) Value = Constrain(Convert.ToDecimal(Convert.ToInt32(text, 16)));
                        else Value = Constrain(decimal.Parse(text, CultureInfo.CurrentCulture));
                    }
                }
                catch
                {
                    // Leave value as it is
                }
                finally
                {
                    UserEdit = false;
                }
            }
            else base.ValidateEditText();
            UpdateEditText();
        }

        private string _Unit;
        [Localizable(true)]
        public string Unit
        {
            get => _Unit;
            set
            {
                if (_Unit != value)
                {
                    _Unit = value;
                    UpdateEditText();
                }
            }
        }

        private decimal Constrain(decimal value)
        {
            if (value < Minimum) value = Minimum;
            if (value > Maximum) value = Maximum;
            return value;
        }
    }
}
