using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PersonalFinanceApp;
using PersonalFinanceApp.Pages.Bills;
using PersonalFinanceApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{ BaseAddress = new Uri("http://localhost:3000/") });

builder.Services.AddScoped<IBillsService, BillService>();

await builder.Build().RunAsync();