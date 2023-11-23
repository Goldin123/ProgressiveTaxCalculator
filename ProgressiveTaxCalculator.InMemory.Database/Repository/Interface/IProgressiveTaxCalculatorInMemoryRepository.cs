using ProgressiveTaxCalculator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.InMemory.Database.Repository.Interface
{
    public interface IProgressiveTaxCalculatorInMemoryRepository
    {
        Task InitialiseDatabaseAsync();
        Task<List<TaxType>> AddTaxTypesAsync(List<TaxType> taxTypes);
        Task<List<TaxTerm>> AddTaxTermsAsync(List<TaxTerm> taxTerms);
        Task<List<PostalCode>> AddPostalCodeAsync(List<PostalCode> postalCodes);
        Task<List<TaxTable>> AddTaxTablesAsync(List<TaxTable> taxTables);
        Task<List<PostalCode>> GetPostalCodesAsync();
    }
}
