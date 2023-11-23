using ProgressiveTaxCalculator.InMemory.Database.Persistence;
using System;

namespace ProgressiveTaxCalculator.Api.Helpers
{
    public static class InMemoryDataSeed
    {
        public static void SeedData(WebApplication app) 
        {
            try
            {
                var scope = app.Services.CreateScope();
                var db = scope.ServiceProvider.GetService<ProgressiveTaxCalculatorInMemoryContext>();
                if (db != null)
                {
                    db.TaxTypes.AddRange(Sandbox.DatabaseTools.GenerateDataValues.SampleData.GenerateSampleTaxTypes());
                    db.TaxTerms.AddRange(Sandbox.DatabaseTools.GenerateDataValues.SampleData.GenerateSampleTaxTerms());
                    db.PostalCodes.AddRange(Sandbox.DatabaseTools.GenerateDataValues.SampleData.GenerateSamplePostalCodes());
                    db.TaxTables.AddRange(Sandbox.DatabaseTools.GenerateDataValues.SampleData.GenerateSampleTaxTables());
                    db.SaveChanges();
                }
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
