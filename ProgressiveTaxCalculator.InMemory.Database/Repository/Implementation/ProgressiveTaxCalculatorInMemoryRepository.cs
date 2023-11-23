using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProgressiveTaxCalculator.InMemory.Database.Persistence;
using ProgressiveTaxCalculator.InMemory.Database.Repository.Interface;
using ProgressiveTaxCalculator.Model.Entities;
using ProgressiveTaxCalculator.Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.InMemory.Database.Repository.Implementation
{
    /// <summary>
    /// Responsible for all in memory data management.
    /// </summary>
    public class ProgressiveTaxCalculatorInMemoryRepository : IProgressiveTaxCalculatorInMemoryRepository
    {
        private readonly ILogger<ProgressiveTaxCalculatorInMemoryRepository> _logger;
        private readonly ProgressiveTaxCalculatorInMemoryContext _memoryContext;

        public ProgressiveTaxCalculatorInMemoryRepository(ILogger<ProgressiveTaxCalculatorInMemoryRepository> logger, ProgressiveTaxCalculatorInMemoryContext memoryContext) 
        {
            _logger = logger;
            _memoryContext = memoryContext;
        }
        
        /// <summary>
        /// This is used to do an initial seeding on the in memory database with a pre-defined set of values, the process is composed of a series of steps.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"> Should anything go wrong, all exceptions are logged.</exception>
        public async Task InitialiseDatabaseAsync()
        {
            try
            {
                _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(InitialiseDatabaseAsync)} starting data initialising process... "));

               //Step 1: Seed tax types data.
               var taxTypes = await SeedTaxTypesDataAsync();

                if (taxTypes?.Count > 0)
                    _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(InitialiseDatabaseAsync)} tax types successfully seeded."));
                else
                    _logger.LogWarning(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(InitialiseDatabaseAsync)} failed to seed tax types."));

                //Step 2: Seed tax terms data.                  
                var taxTerms = await SeedTaxTermsDataAsync();

                if (taxTerms?.Count > 0)
                    _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(InitialiseDatabaseAsync)} tax terms successfully seeded."));
                else
                    _logger.LogWarning(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(InitialiseDatabaseAsync)} failed to seed tax terms."));
                
                //Step 3: Seed postal code data.
                var postalCodes = await SeedPostalCodesDataAsync();

                if (postalCodes?.Count > 0)
                    _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(InitialiseDatabaseAsync)} postal codes successfully seeded."));
                else
                    _logger.LogWarning(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(InitialiseDatabaseAsync)} failed to seed postal codes."));

                //Step 4: Seed tax tables data.
                var taxTables = await SeedTaxTablesDataAsync();
                if (taxTables?.Count > 0)
                    _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(InitialiseDatabaseAsync)} tax tables successfully seeded."));
                else
                    _logger.LogWarning(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(InitialiseDatabaseAsync)} failed to seed tax tables."));

                _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(InitialiseDatabaseAsync)} completed data initialising process. "));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(InitialiseDatabaseAsync)} - {ex.Message}"));

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This adds a collection of tax types into the in memory database.
        /// </summary>
        /// <param name="taxTypes"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<TaxType>> AddTaxTypesAsync(List<TaxType> taxTypes)
        {
            try
            {
                _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(AddTaxTypesAsync)} attempting to add: {String.Join(",", taxTypes)}"));

                if (taxTypes?.Count > 0)
                {
                    
                    await _memoryContext.TaxTypes.AddRangeAsync(taxTypes);

                    await _memoryContext.SaveChangesAsync();

                    _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(AddTaxTypesAsync)} successful added data."));

                    return taxTypes;
                }
                else
                {
                    _logger.LogWarning(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(AddTaxTypesAsync)} has no data to add."));

                    return new List<TaxType>();
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(AddTaxTypesAsync)} - {ex.Message}"));

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// /// This adds a collection of tax terms into the in memory database.
        /// </summary>
        /// <param name="taxTerms"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<TaxTerm>> AddTaxTermsAsync(List<TaxTerm> taxTerms)
        {
            try
            {
                _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(AddTaxTermsAsync)} attempting to add: {String.Join(",", taxTerms)}"));

                if (taxTerms?.Count > 0)
                {

                    await _memoryContext.TaxTerms.AddRangeAsync(taxTerms);

                    await _memoryContext.SaveChangesAsync();
                    
                    _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(AddTaxTermsAsync)} successful added data."));
                    
                    return taxTerms;
                }
                else
                {
                    _logger.LogWarning(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(AddTaxTermsAsync)} has no data to add."));

                    return new List<TaxTerm>();
                }
            }

            catch (Exception ex)
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(AddTaxTermsAsync)} - {ex.Message}"));

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This adds a collection of postal codes into the in memory database.
        /// </summary>
        /// <param name="postalCodes"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<PostalCode>> AddPostalCodeAsync(List<PostalCode> postalCodes)
        {
            try
            {
                _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(AddPostalCodeAsync)} attempting to add: {String.Join(",", postalCodes)}"));

                if (postalCodes?.Count > 0)
                {
                    await _memoryContext.PostalCodes.AddRangeAsync(postalCodes);

                    await _memoryContext.SaveChangesAsync();

                    _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(AddPostalCodeAsync)} successful added data."));

                    return postalCodes;
                }
                else
                {
                    _logger.LogWarning(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(AddPostalCodeAsync)} has no data to add."));

                    return new List<PostalCode>();
                }
            }

            catch (Exception ex)
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(AddPostalCodeAsync)} - {ex.Message}"));

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This adds a collection of tax tables into the in memory database.
        /// </summary>
        /// <param name="taxTables"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<TaxTable>> AddTaxTablesAsync(List<TaxTable> taxTables)
        {
            try
            {
                _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(AddTaxTablesAsync)} attempting to add: {String.Join(",", taxTables)}"));

                if (taxTables?.Count > 0)
                {

                    await _memoryContext.TaxTables.AddRangeAsync(taxTables);

                    await _memoryContext.SaveChangesAsync();


                    _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(AddTaxTablesAsync)} successful added data."));

                    return taxTables;
                }
                else
                {
                    _logger.LogWarning(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(AddTaxTablesAsync)} has no data to add."));

                    return new List<TaxTable>();
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(AddTaxTablesAsync)} - {ex.Message}"));

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PostalCode>> GetPostalCodesAsync() 
        {
            try 
            {
                _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(GetPostalCodesAsync)} attempting to get postal codes."));

                return await _memoryContext.PostalCodes.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(AddTaxTablesAsync)} - {ex.Message}"));

                throw new Exception(ex.Message);
            }
        }

        #region Private members

        /// <summary>
        /// Responsible for seeding tax types data.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<List<TaxType>> SeedTaxTypesDataAsync()
        {
            try
            {
                var taxTypes = new List<TaxType>();
                //Step 1.1: Generate a sample of tax types data.

                _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(SeedTaxTypesDataAsync)} generating tax types data sample. "));

                taxTypes = Sandbox.DatabaseTools.GenerateDataValues.SampleData.GenerateSampleTaxTypes();

                if (taxTypes == null)
                {
                    _logger.LogWarning(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(SeedTaxTypesDataAsync)} failed to generate tax types data sample."));
                    return new List<TaxType>();
                }
                if (taxTypes?.Count > 0)
                {
                    //Step 1.2: Add those tax types to DB.
                    var addTaxTypes = await AddTaxTypesAsync(taxTypes);

                    return addTaxTypes;
                }
                else
                {
                    _logger.LogWarning(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(SeedTaxTypesDataAsync)} no tax types data added."));
                    return new List<TaxType>();
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(SeedTaxTypesDataAsync)} - {ex.Message}"));

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Responsible for seeding tax terms data.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<List<TaxTerm>> SeedTaxTermsDataAsync()
        {
            try
            {
                var taxTerms = new List<TaxTerm>();

                _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(SeedTaxTermsDataAsync)} generating tax terms data sample. "));

                //Step 2.1: Generate a sample of tax terms data.
                taxTerms = Sandbox.DatabaseTools.GenerateDataValues.SampleData.GenerateSampleTaxTerms();

                if (taxTerms == null)
                {
                    _logger.LogWarning(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(SeedTaxTermsDataAsync)} failed to generate tax terms data sample."));
                    return new List<TaxTerm>();
                }
                if (taxTerms?.Count > 0)
                {
                    //Step 2.2: Add those tax terms samples.
                    var addTaxTerms = await AddTaxTermsAsync(taxTerms);

                    return addTaxTerms;
                }
                else
                {
                    _logger.LogWarning(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(SeedTaxTermsDataAsync)} no tax terms data added."));
                    return new List<TaxTerm>();
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(SeedTaxTermsDataAsync)} - {ex.Message}"));

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Responsible for seeding postal codes data.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<List<PostalCode>> SeedPostalCodesDataAsync()
        {
            try
            {
                var postalCodes = new List<PostalCode>();

                _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(SeedPostalCodesDataAsync)} generating postal codes data sample. "));

                //Step 3.1: Generate a sample of postal codes data.
                postalCodes = Sandbox.DatabaseTools.GenerateDataValues.SampleData.GenerateSamplePostalCodes();

                if (postalCodes == null)
                {
                    _logger.LogWarning(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(SeedPostalCodesDataAsync)} failed to generate postal codes data sample."));

                    return new List<PostalCode>();
                }
                if (postalCodes?.Count > 0)
                {
                    //Step 3.2: Add those postal codes samples.
                    var addTaxTerms = await AddPostalCodeAsync(postalCodes);

                    return postalCodes;
                }
                else
                {
                    _logger.LogWarning(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(SeedPostalCodesDataAsync)} no postal codes data added."));

                    return new List<PostalCode>();
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(SeedPostalCodesDataAsync)} - {ex.Message}"));

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Responsible for seeding tax tables data.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<List<TaxTable>> SeedTaxTablesDataAsync() 
        {
            try
            {
                var taxTables = new List<TaxTable>();

                _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(SeedTaxTablesDataAsync)} generating tax tables data sample. "));

                //Step 4.1: Generate a sample of tax tables data.
                taxTables = Sandbox.DatabaseTools.GenerateDataValues.SampleData.GenerateSampleTaxTables();

                if (taxTables == null)
                {
                    _logger.LogWarning(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(SeedTaxTablesDataAsync)} failed to generate tax tables data sample."));

                    return new List<TaxTable>();
                }
                if (taxTables?.Count > 0)
                {
                    //Step 4.2: Add those tax tables samples.
                    var addTaxTerms = await AddTaxTablesAsync(taxTables);

                    return taxTables;
                }
                else
                {
                    _logger.LogWarning(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(SeedTaxTablesDataAsync)} no tax tables data added."));

                    return new List<TaxTable>();
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(SeedTaxTablesDataAsync)} - {ex.Message}"));

                throw new Exception(ex.Message);
            }

        }

        #endregion

    }
}
