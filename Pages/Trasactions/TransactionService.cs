using PersonalFinanceApp.Services;

namespace PersonalFinanceApp.Pages.Trasactions;

public class TransactionService : GenericApiService<Transaction, int>, ITransactionService
{
    public TransactionService(HttpClient httpClient) : base("transactions", httpClient)
    {
    }

}
