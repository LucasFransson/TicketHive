using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TicketHive.Bll.Services.CurrencyApi;
using TicketHive.Bll.Services.Implementations;
using TicketHive.Bll.Services.Interfaces;
using TicketHive.Bll.Services.Managers;
using TicketHive.Client;
using TicketHive.Client.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("TicketHive.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
// Registration of the LocalStorage
builder.Services.AddBlazoredLocalStorage();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("TicketHive.ServerAPI"));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IUnitOfService,UnitOfService>();
builder.Services.AddScoped<LocalStorageManager>();
builder.Services.AddScoped<CheckOutManager>();

builder.Services.AddApiAuthorization();

CurrencyApiHelper.ApiInitializer();

await builder.Build().RunAsync();
