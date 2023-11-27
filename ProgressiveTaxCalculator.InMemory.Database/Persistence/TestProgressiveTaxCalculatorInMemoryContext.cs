using Microsoft.EntityFrameworkCore;
using ProgressiveTaxCalculator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.InMemory.Database.Persistence
{
    public class TestProgressiveTaxCalculatorInMemoryContext : ProgressiveTaxCalculatorInMemoryContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDatabaseNameForTests");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed your data here
            modelBuilder.Entity<TaxType>().HasData(
               Sandbox.DatabaseTools.GenerateDataValues.SampleData.GenerateSampleTaxTypes()
            );
        }
    }
}
