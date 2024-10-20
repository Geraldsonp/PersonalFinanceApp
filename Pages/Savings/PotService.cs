using System;
using PersonalFinanceApp.Services;

namespace PersonalFinanceApp.Pages.Savings;

public class PotService : GenericApiService<Pot, string>, IPotsService
{
    public PotService( HttpClient httpClient) : base("pots", httpClient)
    {
    }
}
