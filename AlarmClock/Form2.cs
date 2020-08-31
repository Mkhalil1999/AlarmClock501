using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmClock
{
    public partial class AddEditForm : Form
    {
        public int returnedYear { get; set; }
        public int returnedMonth { get; set; }
        public int returnedDay { get; set; }
        public int returnedHour { get; set; }
        public int returnedMinute { get; set; }
        public int returnedSecond { get; set; }
        public string alarmEnabled { get; set; }

        public AddEditForm (DateTime inputDateTime, String inputEnabled)
        {
             InitializeComponent();
             this.dateTimePicker.Value = inputDateTime;

            if(inputEnabled=="on")
            {
                this.onCheckBox.Checked = true;
            }
             
        }


        public AddEditForm()
        {
            InitializeComponent();
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            this.returnedYear = dateTimePicker.Value.Year;
            this.returnedMonth = dateTimePicker.Value.Month;
            this.returnedDay = dateTimePicker.Value.Day;
            this.returnedHour = dateTimePicker.Value.Hour;
            this.returnedMinute = dateTimePicker.Value.Minute;
            this.returnedSecond = dateTimePicker.Value.Second;

            if( onCheckBox.Checked == true)
            {
                this.alarmEnabled = "on";
            }
            else
            {
                this.alarmEnabled = "off";
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
