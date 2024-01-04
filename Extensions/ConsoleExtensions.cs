namespace Cola.CoreUtils.Extensions;

public static class ConsoleExtensions
{
    private static string TimestampForma = "[yyyy-MM-dd HH:mm:ss] ";
    
    public static void WriteLine(string format, ConsoleColor foregroundColor = ConsoleColor.White,
        ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        var dt = DateTime.Now.ToString(TimestampForma);
        System.Console.ForegroundColor = foregroundColor;
        System.Console.BackgroundColor = backgroundColor;
        System.Console.WriteLine(dt + format);
        System.Console.ResetColor();
    }
}