using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyBlazorHosted.Libraries.Product;
using MyBlazorHosted.Libraries.ShoppingCart;
using MyBlazorHosted.Libraries.Storage;
using MyBlazorHosted.Client;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var httpClient = new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
};

builder.Services.AddScoped(h => httpClient);

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

using var response = await httpClient.GetAsync("ProductSettings.json");

using var stream = await response.Content.ReadAsStreamAsync();

builder.Configuration.AddJsonStream(stream);


#region Production

using var responseP = await httpClient.GetAsync("ProductSettings."
                                                +
                                                builder.HostEnvironment.Environment
                                                +
                                                ".json");

if (responseP.IsSuccessStatusCode)
{
    using var streamP = await responseP.Content.ReadAsStreamAsync();

    builder.Configuration.AddJsonStream(streamP);
}

#endregion

builder.Services.AddSingleton<IStorageService, StorageService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IShoppingCartService, ShoppingCartService>();

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("fa-IR");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("fa-IR");

builder.Services.AddLocalization();

await builder.Build().RunAsync();
