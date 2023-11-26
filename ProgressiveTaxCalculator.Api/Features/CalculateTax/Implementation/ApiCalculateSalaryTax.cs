using ProgressiveTaxCalculator.Api.Features.CalculateTax.Interface;
using ProgressiveTaxCalculator.Api.Features.GetPostalCodes.Implementation;
using ProgressiveTaxCalculator.Calculator.Features.FlatRateTax.Interface;
using ProgressiveTaxCalculator.Calculator.Features.FlatValueTax.Interface;
using ProgressiveTaxCalculator.Calculator.Features.ProgressiveTax.Interface;
using ProgressiveTaxCalculator.InMemory.Database.Repository.Interface;
using ProgressiveTaxCalculator.Model.Entities;
using ProgressiveTaxCalculator.Model.Objects;

namespace ProgressiveTaxCalculator.Api.Features.CalculateTax.Implementation
{
    public class ApiCalculateSalaryTax : IApiCalculateSalaryTax
    {
        private readonly ILogger<ApiCalculateSalaryTax> _logger;
        private readonly IProgressiveTaxCalculatorInMemoryRepository _inMemoryTaxRepository;
        private readonly IProgressiveTax _progressiveTax;
        private readonly IFlatValueTax _flatValueTax;
        private readonly IFlatRateTax _flatRateTax;
        public ApiCalculateSalaryTax(ILogger<ApiCalculateSalaryTax> logger, IProgressiveTaxCalculatorInMemoryRepository inMemoryTaxRepository, IProgressiveTax progressiveTax, IFlatValueTax flatValueTax, IFlatRateTax flatRateTax ) 
        {
            _logger = logger;
            _inMemoryTaxRepository = inMemoryTaxRepository;
            _progressiveTax = progressiveTax;
            _flatValueTax = flatValueTax;
            _flatRateTax = flatRateTax;
        }
        public async Task<CalculatedTaxResponse> CalculateSalaryTaxAsync(TaxSalaryRequest taxSalaryRequest)
        {
            var calculatedTax = new CalculatedTaxResponse(0, 0, 0, "", "",0);
            
            int.TryParse(taxSalaryRequest.PostalCodeId.ToString(), out int postalCodeId);
            
            decimal.TryParse(taxSalaryRequest.GrossAmount.ToString(), out decimal grossAmount);
            try 
            {
                _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(CalculateSalaryTaxAsync)} attempting to get calculate tax for postal code id {taxSalaryRequest.PostalCodeId} and amount of {taxSalaryRequest.GrossAmount:n}."));

                var taxTables = await _inMemoryTaxRepository.GetAvailableTaxTablesAsync(postalCodeId, 1);

                if(taxTables?.Count > 0) 
                {
                    var calculateRquest = new CalculateTaxRequest(postalCodeId, grossAmount);

                    var taxType = taxTables[0].TaxTypeId;

                    calculateRquest.TaxTables = taxTables;

                    switch (taxType) 
                    {
                        case 1: // Progressive Tax
                            calculatedTax = await _progressiveTax.CalculateTaxAsync(calculateRquest, taxType ?? 0);
                            break;
                        case 2: // Flat Value
                            calculatedTax = await _flatValueTax.CalculateTaxAsync(calculateRquest, taxType ?? 0);
                            break;
                        case 3: // Flat Rate
                            calculatedTax = await _flatRateTax.CalculateTaxAsync(calculateRquest, taxType ?? 0);
                            break;
                        default:
                            break;
                    }

                }
                else 
                {
                    _logger.LogWarning(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(CalculateSalaryTaxAsync)} failed to calculate ."));
                   
                    throw new ArgumentNullException($"No available tax tables available for this postal code ID {postalCodeId}.");
                }
            }
            catch (Exception ex) 
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(CalculateSalaryTaxAsync)} - {ex.Message}"));

                throw new Exception(ex.Message);
            }
            return calculatedTax;
        }
    }
}
