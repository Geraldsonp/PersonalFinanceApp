// Services/BudgetService.cs
using System.Net.Http;
using PersonalFinanceApp.Pages.Budgets;

namespace PersonalFinanceApp.Services
{
    public class BudgetService : GenericApiService<Budget, int>, IBudgetService
    {
        public BudgetService(HttpClient httpClient) : base("budgets", httpClient)
        {
        }

        // Add any budget-specific methods here if needed
    }
}