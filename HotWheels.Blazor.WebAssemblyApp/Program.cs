using HotWheels.Blazor.WebAssemblyApp;
using HotWheelsApp.HttpClients;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Net.Http.Headers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient<IHotWheelsClient, HotWheelsClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5073/");
});


    

await builder.Build().RunAsync();
