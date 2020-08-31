using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AlarmClock
{
    public partial class Form1 : Form
    {
        Timer[] timerArray;
        int count;

        public Form1()
        {
            InitializeComponent();
            timerArray = new Timer[10];
            count = 0;

            readFile();

        }

        private void saveToFile()
        {
            using (StreamWriter sw = new StreamWriter("AlarmsData.txt"))
            {
                foreach (object item in listBox.Items)
                {
                    AlarmObject myObject = (AlarmObject)item;
                    sw.WriteLine(myObject.getAlarmDetails());
                } 

                
            }
        }

        private void readFile()
        {
            string line;
            try
            {

                using (StreamReader sr = new StreamReader("AlarmsData.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);

                        DateTime mySavedTime = DateTime.Parse(line);

                        AlarmObject myObject = new AlarmObject(mySavedTime, "off");
                        listBox.Items.Add(myObject);
                        count++;

                        editButton.Enabled = true;
                       
                    }
                }
            }
            catch (Exception e)
            {

            }
        }


        private void OnTimerEvent(object sender, EventArgs e)
        {
            this.outputLabel.Text = "Alarm went off";

            snoozeButton.Enabled = true;
            stopButton.Enabled = true;
        }  


        private void plusButton_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    
                    DateTime input = new DateTime(form.returnedYear, form.returnedMonth, form.returnedDay, form.returnedHour, form.returnedMinute, form.returnedSecond);
                    AlarmObject myObject = new AlarmObject(input, form.alarmEnabled);

                    listBox.Items.Add(myObject);

                    if (form.alarmEnabled == "on")
                    {

                        DateTime targetTime = new DateTime(form.returnedYear, form.returnedMonth, form.returnedDay, form.returnedHour, form.returnedMinute, form.returnedSecond);

                        DateTime nowTime = DateTime.Now;

                        TimeSpan ts = targetTime.Subtract(nowTime);

                        int milliseconds = (int)ts.TotalMilliseconds;

                        if(milliseconds<0)
                        {
                            errorLabel.Text = "The selected alarm date has to be later than the current date";
                            return;
                        }

                        this.outputLabel.Text = "Status : Alarm is Running ";

                        timerArray[count] = new Timer
                        {
                            Interval = milliseconds
                        };

                        timerArray[count].Enabled = true;

                        timerArray[count].Tick += new System.EventHandler(OnTimerEvent);
                        
                    }


                    count++;
                    
                    editButton.Enabled = true;

                    saveToFile();

                    if (count == 10)
                    {
                        plusButton.Enabled = false;
                    }

                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox.SelectedIndex;

            if(selectedIndex!=-1)
            {
                AlarmObject myObject = (AlarmObject)listBox.SelectedItem;
                using (var form = new AddEditForm(myObject.getTargetTime(), myObject.getEnabled()))
                {
                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        DateTime targetTime = new DateTime(form.returnedYear, form.returnedMonth, form.returnedDay, form.returnedHour, form.returnedMinute, form.returnedSecond);
                       
                        if (timerArray[selectedIndex] != null)
                        {
                            if (timerArray[selectedIndex].Enabled == true)
                            {
                                timerArray[selectedIndex].Stop();
                            }
                        }

                        myObject.setTargetTime(targetTime);
                        myObject.setEnabled(form.alarmEnabled);

                        listBox.Items.RemoveAt(selectedIndex);
                        listBox.Items.Insert(selectedIndex, myObject);

                        saveToFile();

                        if (form.alarmEnabled == "on")
                        {
                            DateTime nowTime = DateTime.Now;

                            TimeSpan ts = targetTime.Subtract(nowTime);

                            int milliseconds = (int)ts.TotalMilliseconds;

                            if (milliseconds < 0)
                            {
                                errorLabel.Text = "The selected alarm date has to be later than the current date";
                                return;
                            }

                            this.outputLabel.Text = "Status : Alarm is Running ";

                            timerArray[selectedIndex] = new Timer
                            {
                                Interval = milliseconds
                            };

                            timerArray[selectedIndex].Enabled = true;

                            timerArray[selectedIndex].Tick += new System.EventHandler(OnTimerEvent);
                        }
                    }


                }



            }
            else
            {
                errorLabel.Text = "Status : Please select an alarm in the box before clicking edit";
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            for(int index=0; index< count;index++)
            {
                if(timerArray[index]!=null)
                {
                    Console.WriteLine(" Alarm " + index + "is not null");
                    if(timerArray[index].Enabled == true)
                    {
                        Console.WriteLine(" Alarm " + index + "is enabled");

                        AlarmObject myObject = (AlarmObject)listBox.Items[index];
                        if (DateTime.Compare(DateTime.Now, myObject.getTargetTime()) >= 0)
                        {
                            timerArray[index].Stop();
                            outputLabel.Text = "Status : alarm stopped";

                            myObject.setEnabled("off");

                            listBox.Items.RemoveAt(index);
                            listBox.Items.Insert(index, myObject);
                            saveToFile();

                        }
                    }
                }
            }
        }

        private void snoozeButton_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < count; index++)
            {
                if (timerArray[index] != null)
                {
                    if (timerArray[index].Enabled == true)
                    {
                        AlarmObject myObject = (AlarmObject)listBox.Items[index];
                        if (DateTime.Compare(DateTime.Now, myObject.getTargetTime()) >= 0)
                        {
                            timerArray[index].Interval = 30000;
                            outputLabel.Text = "Status : alarm is snoozed for 30 seconds";

                        }
                        
                    }
                }
            }
        }
    }
}
