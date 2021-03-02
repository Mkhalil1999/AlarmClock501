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
        int snoozeTiming;
        AlarmSounds sound;
        public delegate void FileManageDel(ListBox x, int y, Button button);
        private FileManageDel ReadFunction;
        private FileManageDel SaveFunction;

        public Form1()
        {
            InitializeComponent();
            timerArray = new Timer[10];
            count = 0;
            ReadFunction = FileManage.Read;
            ReadFunction(listBox, count, editButton);
        }

        private void saveToFile()
        {
            SaveFunction = FileManage.Save;
            SaveFunction(listBox,count,editButton);
        }

       /* private void saveToFile()
        {
            using (StreamWriter sw = new StreamWriter("AlarmsData.txt"))
            {
                foreach (object item in listBox.Items)
                {
                    AlarmObject myObject = (AlarmObject)item;
                    sw.WriteLine(myObject.getAlarmDetails())
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
                        string[] splits = line.Split(' ');
                        DateTime mySavedTime = DateTime.Parse(splits[0]);
                        String mySavedEnabled = splits[1];
                        AlarmSounds mySavedSound = AlarmSounds.Radar;
                        switch (splits[2])
                        {
                            case "Radar":
                                mySavedSound = AlarmSounds.Radar;
                                break;
                            case "Beacon":
                                mySavedSound = AlarmSounds.Beacon;
                                break;
                            case "Chimes":
                                mySavedSound = AlarmSounds.Chimes;
                                break;
                            case "Circuit":
                                mySavedSound = AlarmSounds.Circuit;
                                break;
                            case "Reflection":
                                mySavedSound = AlarmSounds.Reflection;
                                break;
                        }
                        int mySavedSnooze = int.Parse(line);

                        AlarmObject myObject = new AlarmObject(mySavedTime, "off", mySavedSound, mySavedSnooze);
                        listBox.Items.Add(myObject);
                        count++;

                        editButton.Enabled = true;
                       
                    }
                }
            }
            catch (Exception e)
            {

            }
        }*/


        private void OnTimerEvent(object sender, EventArgs e)
        {
            this.outputLabel.Text = "Alarm has gone off. Sound Playing: " + sound.ToString();

            snoozeButton.Enabled = true;
            stopButton.Enabled = true;
        }  


        private void plusButton_Click(object sender, EventArgs e)
        {
            AddEditForm form = new AddEditForm();
            using (form)
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    form.populateList();
                    sound = form.sound;
                    snoozeTiming = form.snoozeTime;
                    DateTime input = new DateTime(form.returnedYear, form.returnedMonth, form.returnedDay, form.returnedHour, form.returnedMinute, form.returnedSecond);
                    AlarmObject myObject = new AlarmObject(input, form.alarmEnabled, sound, snoozeTiming);

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
                using (var form = new AddEditForm(myObject.getTargetTime(), myObject.getEnabled(), myObject.getSound(), myObject.getSnooze()))
                {
                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        DateTime targetTime = new DateTime(form.returnedYear, form.returnedMonth, form.returnedDay, form.returnedHour, form.returnedMinute, form.returnedSecond);
                        AlarmSounds targetSound = form.sound;
                        int targetSnoozeTime = form.snoozeTime;
                       
                        if (timerArray[selectedIndex] != null)
                        {
                            if (timerArray[selectedIndex].Enabled == true)
                            {
                                timerArray[selectedIndex].Stop();
                            }
                        }

                        myObject.setTargetTime(targetTime);
                        myObject.setEnabled(form.alarmEnabled);
                        myObject.setSound(targetSound);
                        myObject.setSnooze(targetSnoozeTime);


                        listBox.Items.RemoveAt(selectedIndex);
                        listBox.Items.Insert(selectedIndex, myObject);

                        saveToFile();

                        if (form.alarmEnabled == "on")
                        {
                            DateTime nowTime = DateTime.Now;

                            TimeSpan ts = targetTime.Subtract(nowTime);

                            int milliseconds = (int)ts.TotalMilliseconds;

                            int snooze = form.snoozeTime;

                            if (milliseconds < 0)
                            {
                                errorLabel.Text = "The selected alarm date has to be later than the current date";
                                return;
                            }

                            if (snooze < 0 && snooze > 30)
                            {
                                errorLabel.Text = "The selected snooze time has to be between 0 and 30 seconds";
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
                    Console.WriteLine(" Alarm " + (index + 1) + "is not null");
                    if(timerArray[index].Enabled == true)
                    {
                        Console.WriteLine(" Alarm " + (index + 1) + "is enabled");

                        AlarmObject myObject = (AlarmObject)listBox.Items[index];
                        if (DateTime.Compare(DateTime.Now, myObject.getTargetTime()) >= 0)
                        {
                            timerArray[index].Stop();
                            outputLabel.Text = "Status : alarm stopped";

                            myObject.setEnabled("off");

                            listBox.Items.RemoveAt(index);
                            listBox.Items.Insert(index, myObject);
                            SaveFunction = FileManage.Save;
                            SaveFunction(listBox,count,editButton);

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
                            timerArray[index].Interval = Convert.ToInt32(snoozeTiming);
                            outputLabel.Text = "Status: alarm is snoozed for " + myObject.getSnooze() + " seconds";

                        }
                        
                    }
                }
            }
        }
    }
}
