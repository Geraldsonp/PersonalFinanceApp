using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PersonalFinanceApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
    { BaseAddress = new Uri(builder.Configuration["serverUrl"] ?? builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();