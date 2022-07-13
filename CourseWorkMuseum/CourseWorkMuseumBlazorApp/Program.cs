using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CourseWorkMuseumBlazorApp;
using CourseWorkMuseumBlazorApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
builder.Services.AddScoped<IExhibitionProvider, ExhibitionProvider>();
builder.Services.AddScoped<IExhibitProvider, ExhibitProvider>();
builder.Services.AddScoped<ITicketProvider, TicketProvider>();
await builder.Build().RunAsync();