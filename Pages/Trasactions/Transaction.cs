using System.Text.Json.Serialization;

namespace PersonalFinanceApp.Pages.Trasactions;

public class Transaction
{
    public string Avatar { get; set; }
    public string RecipientOrSender { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public TransactionType Type { get; set; }
}


[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TransactionType
{
    Expense,
    Income
}