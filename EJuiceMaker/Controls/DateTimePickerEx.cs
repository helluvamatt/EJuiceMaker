using System;
using System.Windows.Forms;

namespace EJuiceMaker.Controls
{
    public partial class DateTimePickerEx : UserControl
    {
        public DateTimePickerEx()
        {
            InitializeComponent();
        }

        public bool Checked
        {
            get => checkBox.Checked;
            set => checkBox.Checked = value;
        }

        public DateTime Value
        {
            get => datePicker.Value.Date + timePicker.Value.TimeOfDay;
            set
            {
                datePicker.Value = value.Date;
                timePicker.Value = DateTime.Today + value.TimeOfDay;
            }
        }
    }
}
