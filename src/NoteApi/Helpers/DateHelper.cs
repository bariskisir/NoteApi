using System;
namespace NoteApi.Helpers
{
    public static class DateHelper
    {
        public static DateTime DateTime1970 = new DateTime(1970, 1, 1).ToLocalTime();
        public static long GetTimeStamp()
        {
            return (long)(DateTime.Now.ToLocalTime() - DateTime1970).TotalSeconds;
        }
        public static long GetTimeStamp(DateTime dateTime)
        {
            return (long)(dateTime.ToLocalTime() - DateTime1970).TotalSeconds;
        }
    }
}
