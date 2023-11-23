using Microsoft.EntityFrameworkCore;
using ProgressiveTaxCalculator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.InMemory.Database.Persistence
{
    public class ProgressiveTaxCalculatorInMemoryContext : DbContext
    {
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TaxCalculatorInMemoryDatabase");
        }

        public DbSet<TaxType> TaxTypes { get; set; }
        public DbSet<TaxTerm> TaxTerms { get; set; }        
        public DbSet<PostalCode> PostalCodes { get; set; }
        public DbSet<TaxTable> TaxTables { get; set; }
        public DbSet<TaxCalculated> TaxCalculated { get; set; }        
    }
}
