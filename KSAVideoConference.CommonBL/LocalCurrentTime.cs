using System;

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
