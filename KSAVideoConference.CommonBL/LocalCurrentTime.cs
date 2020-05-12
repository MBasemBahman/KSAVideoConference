using System;
using System.Collections.Generic;
using System.Text;

namespace KSAVideoConference.CommonBL
{
    public static class LocalCurrentTime
    {
        public static DateTime GetLocalCurrentTime(string timeZone = "Egypt Standard Time")
        {
            DateTime localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, timeZone);
            return localTime;
        }
    }
}
