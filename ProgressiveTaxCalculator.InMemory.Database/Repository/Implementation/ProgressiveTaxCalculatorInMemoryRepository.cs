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

        public ProgressiveTaxCalculatorInMemoryRepository(ILogger<ProgressiveTaxCalculatorInMemoryRepository> logger) 
        {
            _logger = logger;
        }
        /// <summary>
        /// This is used to seed the in memory database with a pre defined set of values, the process is composed of a series of steps.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"> Should anything go wrong, all exceptions are logged.</exception>
        public async Task InitialiseDatabaseAsync()
        {
            try
            {
                var postalCodes = new List<PostalCode>();

                _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(InitialiseDatabaseAsync)} starting data initialising process... "));

               //Step 1: Seed tax types data.
               var taxTypes = await SeedTaxTypesDataAsync();

                if (taxTypes?.Count > 0)
                {
                    //Step 2: Seed tax terms data.                  
                    var taxTerms = await SeedTaxTermsDataAsync();

                    if (taxTerms?.Count > 0)
                    {
                       
                    }
                    else
                        _logger.LogWarning(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(InitialiseDatabaseAsync)} no tax terms data sample available."));
                }
                else
                    _logger.LogWarning(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(InitialiseDatabaseAsync)} no tax types data sample available."));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(InitialiseDatabaseAsync)} - {ex.Message}"));

                throw new Exception(ex.Message);
            }
        }

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
            catch(Exception ex) 
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
        /// This adds a collection of tax types into the in memory database
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
                    using (var db = new ProgressiveTaxCalculatorInMemoryContext())
                    {
                        await db.TaxTypes.AddRangeAsync(taxTypes);

                        await db.SaveChangesAsync();
                    }

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
        /// /// This adds a collection of tax terms into the in memory database
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
                    using (var db = new ProgressiveTaxCalculatorInMemoryContext())
                    {
                        await db.TaxTerms.AddRangeAsync(taxTerms);

                        await db.SaveChangesAsync();
                    }

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

    }
}
