using PersonalFinanceApp.Services;

namespace PersonalFinanceApp.Pages.Bills;

public class BillService : GenericApiService<Bill, int>, IBillsService
{
    private readonly HttpClient httpClient;



    public BillService(HttpClient httpClient) : base("bills", httpClient)
    {
        this.httpClient = httpClient;
    }

}
