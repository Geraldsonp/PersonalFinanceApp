using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PersonalFinanceApp;
using PersonalFinanceApp.ErrorHandling;
using PersonalFinanceApp.LoadingStateManagment;
using PersonalFinanceApp.Pages.Bills;
using PersonalFinanceApp.Pages.Savings;
using PersonalFinanceApp.Pages.Trasactions;
using PersonalFinanceApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddTransient<LoadingAndErrorHttpInterceptor>();
builder.Services.AddHttpClient("Default", client => client.BaseAddress = new Uri("http://localhost:3000/"))
    .AddHttpMessageHandler<LoadingAndErrorHttpInterceptor>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Default"));


builder.Services.AddScoped<IBillsService, BillService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IBudgetService, BudgetService>();
builder.Services.AddScoped<IColorsService, ColorsService>();
builder.Services.AddScoped<ICategoryService, CategoriesService>();
builder.Services.AddScoped<IPotsService, PotService>();
builder.Services.AddSingleton<IErrorHandler, GlobalErrorHandler>();
builder.Services.AddSingleton<LoadingService>();


await builder.Build().RunAsync();