using System;
using PersonalFinanceApp.Models;

namespace PersonalFinanceApp.Pages.Savings;

public class Pot : IHasId
{
    public string Name { get; set; }
    public int Target { get; set; }
    public int Total { get; set; }
    public string Theme { get; set; }
    public string Id { get; set; }
}
