using System;

namespace PersonalFinanceApp.Pages.Budgets.Models;

public class SpendingSummary
{
    public string Category { get; set; }
    public decimal Spent { get; set; }
    public decimal Limit { get; set; }

    public string Color { get; set; }
}