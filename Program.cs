using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PersonalFinanceApp;
using PersonalFinanceApp.Pages.Bills;
using PersonalFinanceApp.Pages.Trasactions;
using PersonalFinanceApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{ BaseAddress = new Uri("http://localhost:3000/") });

builder.Services.AddScoped<IBillsService, BillService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IBudgetService, BudgetService>();
builder.Services.AddScoped<IColorsService, ColorsService>();
builder.Services.AddScoped<ICategoryService, CategoriesService>();
builder.Services.AddSingleton<AppState>();

await builder.Build().RunAsync();