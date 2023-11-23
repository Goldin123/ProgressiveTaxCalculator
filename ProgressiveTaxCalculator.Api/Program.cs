
using ProgressiveTaxCalculator.Api.Features.GetPostalCodes.Implementation;
using ProgressiveTaxCalculator.Api.Features.GetPostalCodes.Interface;
using ProgressiveTaxCalculator.Api.Helpers;
using ProgressiveTaxCalculator.InMemory.Database.Persistence;
using ProgressiveTaxCalculator.InMemory.Database.Repository.Implementation;
using ProgressiveTaxCalculator.InMemory.Database.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ProgressiveTaxCalculatorInMemoryContext>();
builder.Services.AddScoped<IProgressiveTaxCalculatorInMemoryRepository, ProgressiveTaxCalculatorInMemoryRepository>();
builder.Services.AddScoped<IApiGetPostalCodes, ApiGetPostalCodes>();

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
