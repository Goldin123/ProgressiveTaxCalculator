using ProgressiveTaxCalculator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Sandbox.DatabaseTools.GenerateDataValues
{
    public static class SampleData
    {
        public static List<TaxType> GenerateSampleTaxTypes()
        {
            return new List<TaxType>()
            {
                new TaxType { Active = true, DateAdded = DateTime.Now, DateUpdate = DateTime.Now, Id = 1, TaxTypeName = "Progressive" },
                new TaxType { Active = true, DateAdded = DateTime.Now, DateUpdate = DateTime.Now, Id = 2, TaxTypeName = "Flat Value" },
                new TaxType { Active = true, DateAdded = DateTime.Now, DateUpdate = DateTime.Now, Id = 3, TaxTypeName = "Flat Rate" }
            };
        }

        public static List<TaxTerm> GenerateSampleTaxTerms()
        {
            return new List<TaxTerm>()
            {
                new TaxTerm { Active = true, Id = 1, TaxTermName = "Annual", DateAdded = DateTime.Now, DateUpdate = DateTime.Now }
            };
        }

        public static List<PostalCode> GenerateSamplePostalCodes()
        {
            return new List<PostalCode>()
            {
                new PostalCode { Active = true, DateUpdate = DateTime.Now, Id = 1, DateAdded = DateTime.Now, Code = "7441", TaxTypeId = 1 },
                new PostalCode { Active = true, DateUpdate = DateTime.Now, Id = 2, DateAdded = DateTime.Now, Code = "A100", TaxTypeId = 2 },
                new PostalCode { Active = true, DateUpdate = DateTime.Now, Id = 3, DateAdded = DateTime.Now, Code = "7000", TaxTypeId = 3 },
                new PostalCode { Active = true, DateUpdate = DateTime.Now, Id = 4, DateAdded = DateTime.Now, Code = "1000", TaxTypeId = 1 },
            };
        }

        public static List<TaxTable> GenerateSampleTaxTables()
        {
            return new List<TaxTable>()
            {
                new TaxTable { Id = 1,  Active = true, TaxTermId = 1, DateAdded = DateTime.Now, DateUpdate = DateTime.Now , TaxTypeId = 1, PostalCodeId = 1, Amount = 8350m, TaxPercentage = 0.10m, UsePercentage = true },
                new TaxTable { Id = 2,  Active = true, TaxTermId = 1, DateAdded = DateTime.Now, DateUpdate = DateTime.Now , TaxTypeId = 1, PostalCodeId = 1, Amount = 33950m, TaxPercentage = 0.15m, UsePercentage = true },
                new TaxTable { Id = 3,  Active = true, TaxTermId = 1, DateAdded = DateTime.Now, DateUpdate = DateTime.Now , TaxTypeId = 1, PostalCodeId = 1, Amount = 82250m, TaxPercentage = 0.25m, UsePercentage = true },
                new TaxTable { Id = 4,  Active = true, TaxTermId = 1, DateAdded = DateTime.Now, DateUpdate = DateTime.Now , TaxTypeId = 1, PostalCodeId = 1, Amount = 171550m, TaxPercentage = 0.28m, UsePercentage = true },
                new TaxTable { Id = 5,  Active = true, TaxTermId = 1, DateAdded = DateTime.Now, DateUpdate = DateTime.Now , TaxTypeId = 1, PostalCodeId = 1, Amount = 372950m, TaxPercentage = 0.33m, UsePercentage = true },
                new TaxTable { Id = 6,  Active = true, TaxTermId = 1, DateAdded = DateTime.Now, DateUpdate = DateTime.Now , TaxTypeId = 1, PostalCodeId = 1, Amount = decimal.MaxValue, TaxPercentage = 0.35m, UsePercentage = true },
                new TaxTable { Id = 7,  Active = true, TaxTermId = 1, DateAdded = DateTime.Now, DateUpdate = DateTime.Now , TaxTypeId = 1, PostalCodeId = 4, Amount = 8350m, TaxPercentage = 0.10m, UsePercentage = true },
                new TaxTable { Id = 8,  Active = true, TaxTermId = 1, DateAdded = DateTime.Now, DateUpdate = DateTime.Now , TaxTypeId = 1, PostalCodeId = 4, Amount = 33950m, TaxPercentage = 0.15m, UsePercentage = true },
                new TaxTable { Id = 9,  Active = true, TaxTermId = 1, DateAdded = DateTime.Now, DateUpdate = DateTime.Now , TaxTypeId = 1, PostalCodeId = 4, Amount = 82250m, TaxPercentage = 0.25m, UsePercentage = true },
                new TaxTable { Id = 10, Active = true, TaxTermId = 1, DateAdded = DateTime.Now, DateUpdate = DateTime.Now , TaxTypeId = 1, PostalCodeId = 4, Amount = 171550m, TaxPercentage = 0.28m, UsePercentage = true },
                new TaxTable { Id = 11, Active = true, TaxTermId = 1, DateAdded = DateTime.Now, DateUpdate = DateTime.Now , TaxTypeId = 1, PostalCodeId = 4, Amount = 372950m, TaxPercentage = 0.33m, UsePercentage = true },
                new TaxTable { Id = 12, Active = true, TaxTermId = 1, DateAdded = DateTime.Now, DateUpdate = DateTime.Now , TaxTypeId = 1, PostalCodeId = 4, Amount = decimal.MaxValue, TaxPercentage = 0.35m, UsePercentage = true },
                new TaxTable { Id = 13, Active = true, TaxTermId = 1, DateAdded = DateTime.Now, DateUpdate = DateTime.Now , TaxTypeId = 2, PostalCodeId = 2, Amount = 199999.99m, TaxPercentage = 0.05m, UsePercentage = true }, //Flat Value
                new TaxTable { Id = 14, Active = true, TaxTermId = 1, DateAdded = DateTime.Now, DateUpdate = DateTime.Now , TaxTypeId = 2, PostalCodeId = 2, Amount = decimal.MaxValue, TaxPercentage = 10000m, UsePercentage = false}, //Flat Value
                new TaxTable { Id = 15, Active = true, TaxTermId = 1, DateAdded = DateTime.Now, DateUpdate = DateTime.Now , TaxTypeId = 3, PostalCodeId = 3, Amount = decimal.MaxValue, TaxPercentage = 0.175m , UsePercentage = true }, //Flat Rate
            };
        }
    }
}
