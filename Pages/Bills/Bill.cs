namespace PersonalFinanceApp.Pages.Bills;

public class Bill
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }

    public Bill(int id, string name, decimal amount, string category)
    {
        Id = id;
        Name = name;
        Amount = amount;
        Category = category;
    }

    protected Bill()
    {

    }
}
