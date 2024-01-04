namespace Cola.CoreUtils.Extensions;

public static class IntegerExtensions
{
    /// <summary>
    /// convert string to decimal
    /// </summary>
    /// <param name="i"><paramref name="i" /> intger</param>
    /// <returns>decimal number</returns>
    public static decimal IntToDecimal(this int i)
    {
        return Convert.ToDecimal(i);
    }
}