using LaptopsMonitor.Dashboard;
using LaptopsMonitor.Dashboard.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddSerializerJsonOptions()
    .AddLaptopDataClient();

await builder.Build().RunAsync();