using Cola.CoreUtils.Enums;

namespace Cola.CoreUtils.Extensions;

public static class DateTimeExtensions
{
    public static long DateTimeToUnixTime(this DateTime dt, EnumSsOrMs? ssOrMs = EnumSsOrMs.Ms)
    {
        DateTime baseTime = new(1970, 1, 1);
        if (ssOrMs == null || ssOrMs == EnumSsOrMs.Ss)
        {
            return (dt.ToLocalTime().Ticks - baseTime.ToLocalTime().Ticks) / 10000000;
        }
        return (dt.ToLocalTime().Ticks - baseTime.ToLocalTime().Ticks) / 10000;
    }
}