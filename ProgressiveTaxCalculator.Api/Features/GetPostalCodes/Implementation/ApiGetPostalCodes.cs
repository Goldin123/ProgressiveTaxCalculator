using ProgressiveTaxCalculator.Api.Controllers;
using ProgressiveTaxCalculator.Api.Features.GetPostalCodes.Interface;
using ProgressiveTaxCalculator.InMemory.Database.Repository.Interface;
using ProgressiveTaxCalculator.Model.Entities;

namespace ProgressiveTaxCalculator.Api.Features.GetPostalCodes.Implementation
{
    public class ApiGetPostalCodes : IApiGetPostalCodes
    {
        private readonly ILogger<ApiGetPostalCodes> _logger;
        private readonly IProgressiveTaxCalculatorInMemoryRepository _inMemoryTaxRepository;

        public ApiGetPostalCodes(ILogger<ApiGetPostalCodes> logger, IProgressiveTaxCalculatorInMemoryRepository inMemoryTaxRepository) 
        {
            _logger = logger;
            _inMemoryTaxRepository = inMemoryTaxRepository;
        }

        public async Task<List<PostalCode>> GetPostalCodes() 
        {
            try 
            { 
                return await _inMemoryTaxRepository.GetPostalCodesAsync();
            }
            catch (Exception ex) 
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(GetPostalCodes)} - {ex.Message}"));

                throw new Exception(ex.Message);
            }
        }

    }
}
