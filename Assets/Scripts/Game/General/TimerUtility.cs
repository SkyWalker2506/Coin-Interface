using System;

public static class TimerUtility
{
    static DateTime firstDt = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

    public static DateTime CurrentTime
    {
        get
        {
            return DateTime.UtcNow;
        }
    }

    public static DateTime ConvertTimestampToDateTime(double timestamp)
    {
        return firstDt.AddSeconds(timestamp);
    }

    public static double ConvertDateTimeToTimestamp(DateTime dateTime)
    {
        return (dateTime - firstDt).TotalSeconds;
    }
}
