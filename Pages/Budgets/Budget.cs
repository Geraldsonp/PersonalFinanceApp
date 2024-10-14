using System;

namespace PersonalFinanceApp.Pages.Budgets;

public class Budget
{
    public int Id { get; set; } = new Random().Next();
    public string Category { get; set; }
    public decimal Maximum { get; set; }
    public string Theme { get; set; }
}