using ProgressiveTaxCalculator.CustomMiddleware.TaxManagerService.Implementation;
using ProgressiveTaxCalculator.CustomMiddleware.TaxManagerService.Interface;
using ProgressiveTaxCalculator.Sandbox.ApiTools.Client.Implementation;
using ProgressiveTaxCalculator.Sandbox.ApiTools.Client.Interface;
using ProgressiveTaxCalculator.Sandbox.Generics.Implementation;
using ProgressiveTaxCalculator.Sandbox.Generics.Interface;
using ProgressiveTaxCalculator.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IPostalCodeManager, PostalCodeManager>();
builder.Services.AddScoped<IClientOrchestratorAgent, ClientOrchestratorAgent>();
builder.Services.AddScoped<IApplicationGenerics, ApplicationGenerics>();
builder.Services.AddScoped<ITaxCalculatorManager, TaxCalculatorManager>();

builder.Services.AddControllersWithViews();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
