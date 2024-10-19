namespace PersonalFinanceApp.Components.Dropdown;

public record DropdownOption<TKey>(TKey Value, string Label, string Color = "", bool IsUsed = false) where TKey : IEquatable<TKey>;
