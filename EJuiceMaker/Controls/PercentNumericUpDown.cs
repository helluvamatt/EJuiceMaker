using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EJuiceMaker.Controls
{
    internal class PercentNumericUpDown : NumericUpDown
    {
        private const decimal DefaultVal = 0m;
        private const decimal DefaultMin = 0m;
        private const decimal DefaultMax = 1m;
        private const decimal DefaultInc = 0.01m;

        public PercentNumericUpDown()
        {
            Value = DefaultVal;
            Minimum = DefaultMin;
            Maximum = DefaultMax;
            Increment = DefaultInc;
        }

        protected override void UpdateEditText()
        {
            if (UserEdit) ParseEditText();
            Text = Value.ToString(string.Format("p{0}", DecimalPlaces), CultureInfo.CurrentCulture);
        }

        protected new void ParseEditText()
        {
            try
            {
                if (!string.IsNullOrEmpty(Text) && (Text.Length != 1 || Text != "-"))
                {
                    Value = Constrain(decimal.Parse(Text.Replace(CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, string.Empty), NumberStyles.Any, CultureInfo.CurrentCulture) / 100m);
                }
            }
            catch (Exception)
            {
                // Leave value as it is
            }
            finally
            {
                UserEdit = false;
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
