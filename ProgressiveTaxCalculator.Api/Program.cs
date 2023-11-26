
using ProgressiveTaxCalculator.Api.Features.CalculateTax.Implementation;
using ProgressiveTaxCalculator.Api.Features.CalculateTax.Interface;
using ProgressiveTaxCalculator.Api.Features.GetPostalCodes.Implementation;
using ProgressiveTaxCalculator.Api.Features.GetPostalCodes.Interface;
using ProgressiveTaxCalculator.Api.Helpers;
using ProgressiveTaxCalculator.Calculator.Features.FlatRateTax.Implementation;
using ProgressiveTaxCalculator.Calculator.Features.FlatRateTax.Interface;
using ProgressiveTaxCalculator.Calculator.Features.FlatValueTax.Implementation;
using ProgressiveTaxCalculator.Calculator.Features.FlatValueTax.Interface;
using ProgressiveTaxCalculator.Calculator.Features.ProgressiveTax.Implementation;
using ProgressiveTaxCalculator.Calculator.Features.ProgressiveTax.Interface;
using ProgressiveTaxCalculator.InMemory.Database.Persistence;
using ProgressiveTaxCalculator.InMemory.Database.Repository.Implementation;
using ProgressiveTaxCalculator.InMemory.Database.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ProgressiveTaxCalculatorInMemoryContext>();
builder.Services.AddScoped<IProgressiveTaxCalculatorInMemoryRepository, ProgressiveTaxCalculatorInMemoryRepository>();
builder.Services.AddScoped<IApiGetPostalCodes, ApiGetPostalCodes>();
builder.Services.AddScoped<IApiCalculateSalaryTax, ApiCalculateSalaryTax>();
builder.Services.AddScoped<IProgressiveTax, ProgressiveTax>();
builder.Services.AddScoped<IFlatValueTax, FlatValueTax>();
builder.Services.AddScoped<IFlatRateTax, FlatRateTax>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

InMemoryDataSeed.SeedData(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
