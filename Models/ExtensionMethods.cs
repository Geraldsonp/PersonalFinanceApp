using System;

namespace PersonalFinanceApp.Models;

public static class ExtensionMethods
{

    public static IOrderedEnumerable<T> OrderByDirection<T, TKey>(IEnumerable<T> source, Func<T, TKey> keySelector, bool isDescending)
    {
        return isDescending ? source.OrderByDescending(keySelector) : source.OrderBy(keySelector);
    }

}
