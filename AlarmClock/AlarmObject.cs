using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock
{
    class AlarmObject
    {

        private DateTime targetTime;

        public DateTime getTargetTime()
        {
            return targetTime;
        }

        public void setTargetTime(DateTime inputDateTime)
        {
            targetTime = inputDateTime;
        }

        private String enabled;

        public String getEnabled()
    { return enabled; }

        public void setEnabled(String inputEnabled)
    {
        enabled = inputEnabled;
    }


        public AlarmObject(DateTime inputDateTime,String inputEnabled)
        {
            this.targetTime = inputDateTime;
            this.enabled = inputEnabled;
        }

        public override string ToString()
        {
            return targetTime.ToString("h:mm tt") + " " + enabled;
        }

        public string getAlarmDetails()
        {
            return targetTime.ToString();
        }


    }
}
