using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock
{
    class AlarmObject
    {
        //Set the time
        private DateTime targetTime;

        public DateTime getTargetTime()
        {
            return targetTime;
        }

        public void setTargetTime(DateTime inputDateTime)
        {
            targetTime = inputDateTime;
        }
        //Set on/off.
        private String enabled;

        public String getEnabled()
        { return enabled; }

        public void setEnabled(String inputEnabled)
        {
        enabled = inputEnabled;
        }
        //Set the alarm sound
        private AlarmSounds sound;
        public AlarmSounds getSound() 
        { return sound;}

        public void setSound(AlarmSounds inputsound)
        {
            sound = inputsound;
        }
        //Set the snooze
        private int snooze;
        public int getSnooze()
        { return snooze; }

        public void setSnooze(int inputsnooze)
        {
            snooze = inputsnooze;
        }

        public AlarmObject(DateTime inputDateTime,String inputEnabled, AlarmSounds inputSound, int inputSnooze)
        {
            this.targetTime = inputDateTime;
            this.enabled = inputEnabled;
            this.sound = inputSound;
            this.snooze = inputSnooze;
        }

        public override string ToString()
        {
            return targetTime.ToString("h:mm tt");

        }

        public string getAlarmDetails()
        {
            return targetTime.ToString("h:mm tt") + " " + enabled + " " + sound + " " + snooze;
        }


    }
}
