using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmClock
{
    public class FileManage
    {
        public static void Save(ListBox x, int y, Button button)
        {
            using (StreamWriter sw = new StreamWriter("AlarmsData.txt"))
            {
                foreach (object item in x.Items)
                {
                    AlarmObject myObject = (AlarmObject)item;
                    sw.WriteLine(myObject.getAlarmDetails());
                    y = x.Items.Count;
                    button.Enabled = true;
                }


            }
        }

        public static void Read(ListBox x, int y, Button button)
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
                        x.Items.Add(myObject);
                        y++;

                        button.Enabled = true;

                    }
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show("Somehting went wrong");
            }
        }

    }
}
