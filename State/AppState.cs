using PersonalFinanceApp.Pages.Budgets;
using PersonalFinanceApp.Pages.Trasactions;

public class AppState
{
    // State properties
    public IEnumerable<Transaction> Transactions { get; private set; } = new List<Transaction>();
    public IEnumerable<Budget> Budgets { get; private set; } = new List<Budget>();
    public decimal CurrentBalance { get; private set; }

    // Events for state changes
    public event Action OnChange;

    // Methods to update state
    public void SetTransactions(IEnumerable<Transaction> transactions)
    {
        Transactions = transactions;
        NotifyStateChanged();
    }

    public void SetBudgets(IEnumerable<Budget> budgets)
    {
        Budgets = budgets;
        NotifyStateChanged();
    }

    public void UpdateBalance(decimal newBalance)
    {
        CurrentBalance = newBalance;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}