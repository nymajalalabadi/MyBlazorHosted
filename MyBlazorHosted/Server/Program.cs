using Microsoft.AspNetCore.ResponseCompression;
using MyBlazorHosted.Libraries.Product;
using MyBlazorHosted.Libraries.ShoppingCart;
using MyBlazorHosted.Libraries.Storage;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IStorageService, StorageService>();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IShoppingCartService, ShoppingCartService>();

builder.Host.UseSerilog((hb, lc) => lc.ReadFrom.Configuration(hb.Configuration));

#region Add Cors

//builder.Services.AddCors(option =>
//{
//    option.AddPolicy("blazorWasm", policy =>
//    {
//        policy.WithOrigins("https://localhost:7249")
//        .AllowAnyHeader()
//        .AllowAnyMethod();
//    });
//});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSerilogIngestion();
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

#region MyRegion

//app.UseCors("blazorWasm");

#endregion

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
