using System.ComponentModel;
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
    }
}
