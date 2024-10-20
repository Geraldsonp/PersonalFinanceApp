using System;

namespace PersonalFinanceApp.Utils;

public static class StringUtils
{
    public static string Capitalize(this string value)
    {
        return value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
    }

    public static string ToLocalCurrency(this double value)
    {
        return $"{value:C2}";
    }

    public static string ToLocalCurrency(this decimal value)
    {
        return $"{value:C2}";
    }

    public static string ToLocalCurrency(this string value)
    {
        return $"{value:C2}";
    }

    public static string ToLocalCurrency(this int value)
    {
        return $"{value:N2}";
    }
}
