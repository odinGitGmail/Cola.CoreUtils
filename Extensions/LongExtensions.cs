namespace Cola.CoreUtils.Extensions;

public static class LongExtensions
{
    public static DateTime LongToDateTime(this long unixTime)
    {
        DateTime baseTime = new(1970, 1, 1);
        DateTime dtStart = TimeZoneInfo.ConvertTime(baseTime,TimeZoneInfo.Local);
        long lTime = long.Parse(unixTime + "0000000");
        TimeSpan toNow = new TimeSpan(lTime);
        return dtStart.Add(toNow);
    }
}