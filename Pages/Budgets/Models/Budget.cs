using System;
using PersonalFinanceApp.Models;

namespace PersonalFinanceApp.Pages.Budgets;

public class Budget : IHasId
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Maximum { get; set; }
    public string Theme { get; set; }
}