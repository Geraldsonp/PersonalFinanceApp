using System;

namespace PersonalFinanceApp.Pages.Budgets.Models;

public class NewBudgetDto
{

    public string Category { get; set; }
    public decimal MaxSpend { get; set; }
    public string Theme { get; set; }
}
