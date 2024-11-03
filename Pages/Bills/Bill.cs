namespace PersonalFinanceApp.Pages.Bills;

public class Bill
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public bool IsPaid { get; set; } = false;
    public DateTime DueDate { get; set; }
    public string? Avatar { get; set; }


    public Bill(int id, string name, decimal amount, string category, DateTime dueDate)
    {
        Id = id;
        Name = name;
        Amount = amount;
        Category = category;
        DueDate = dueDate;
    }

    protected Bill()
    {

    }
}
