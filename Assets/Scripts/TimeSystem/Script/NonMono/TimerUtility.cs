using System;


namespace TimeSystem
{
    public static class TimerUtility
    {
        public static DateTime FirstDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        public static DateTime CurrentTime => DateTime.UtcNow;
        public const int SecondsPerDay = 86400;
        public static DateTime ConvertTimestampToDateTime(double timestamp)
        {
            return FirstDate.AddSeconds(timestamp);
        }

        public static double ConvertDateTimeToTimestamp(DateTime dateTime)
        {
            return (dateTime - FirstDate).TotalSeconds;
        }
    }
}
