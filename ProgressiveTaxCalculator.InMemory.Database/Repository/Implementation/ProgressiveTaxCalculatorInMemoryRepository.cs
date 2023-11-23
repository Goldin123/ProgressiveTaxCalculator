using Microsoft.Extensions.Logging;
using ProgressiveTaxCalculator.InMemory.Database.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.InMemory.Database.Repository.Implementation
{
    public class ProgressiveTaxCalculatorInMemoryRepository : IProgressiveTaxCalculatorInMemoryRepository
    {
        private readonly ILogger<ProgressiveTaxCalculatorInMemoryRepository> _logger;

        public ProgressiveTaxCalculatorInMemoryRepository(ILogger<ProgressiveTaxCalculatorInMemoryRepository> logger) 
        {
            _logger = logger;
        }

        public async Task InitialiseDatabase()
        {
            try
            {

                await AddTaxBrackets(_taxLevels);

            }
            catch (Exception ex)
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, ex.Message));
                throw new Exception(ex.Message);
            }
        }
    }
}
