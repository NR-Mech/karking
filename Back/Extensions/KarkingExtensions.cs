namespace Karking.Back.Extensions;

public static class KarkingExtensions
{
    public static string GetPayToken()
    {
        var justNumbers = Guid.NewGuid().ToString().OnlyNumbers();
        return justNumbers[..4];
    }

    public static string ToStr(this DateTime dateTime)
    {
        return dateTime.AddHours(-3).ToString("MM/dd/yyyy HH:mm:ss");
    }

    public static string? ToStr(this DateTime? dateTime)
    {
        return dateTime?.AddHours(-3).ToString("MM/dd/yyyy HH:mm:ss");
    }

    public static string OnlyNumbers(this string text)
    {
        if (text.HasValue())
        {
            return new string(text.Where(char.IsDigit).ToArray());
        }

        return "";
    }

    public static bool HasValue(this string? text)
    {
        return !string.IsNullOrEmpty(text);
    }
}
