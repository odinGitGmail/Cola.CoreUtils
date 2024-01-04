namespace Cola.CoreUtils.Extensions;

public static class DecimalExtensions
{
    /// <summary>
    /// convert decimal to int
    /// </summary>
    /// <param name="d"><paramref name="d" /> decimal</param>
    /// <returns>integer number</returns>
    public static int DecimalToInt(this decimal d)
    {
        return Convert.ToInt32(d);
    }
}