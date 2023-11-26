using Microsoft.Extensions.Logging;
using ProgressiveTaxCalculator.Calculator.Features.ProgressiveTax.Interface;
using ProgressiveTaxCalculator.InMemory.Database.Repository.Interface;
using ProgressiveTaxCalculator.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Calculator.Features.ProgressiveTax.Implementation
{
    public class ProgressiveTax : IProgressiveTax
    {
        private readonly ILogger<ProgressiveTax> _logger;
        private readonly IProgressiveTaxCalculatorInMemoryRepository _inMemoryTaxRepository;

        public ProgressiveTax(ILogger<ProgressiveTax> logger, IProgressiveTaxCalculatorInMemoryRepository inMemoryTaxRepository)
        {
            _logger = logger;
            _inMemoryTaxRepository = inMemoryTaxRepository;
        }
        /// <summary>
        /// Progressive tax calculation.
        /// </summary>
        /// <param name="calculateTaxRequest"></param>
        /// <param name="taxType"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<CalculatedTaxResponse> CalculateTaxAsync(CalculateTaxRequest calculateTaxRequest,int taxType)
        {
            var calculatedTax = new CalculatedTaxResponse(0, 0, 0, "", "", 0);

            try
            {
                _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(CalculateTaxAsync)} starting progressing tax calculation for amount {calculateTaxRequest.GrossAmount:n}."));

                if (calculateTaxRequest.TaxTables?.Count() > 0)
                {
                    foreach (var taxTable in calculateTaxRequest.TaxTables)
                    {
                        if (calculateTaxRequest.GrossAmount <= taxTable.Amount)
                        {

                            calculatedTax.TaxPercentage = taxTable.TaxPercentage;

                            _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(CalculateTaxAsync)} tax percentage to use: {taxTable.TaxPercentage:n}."));

                            calculatedTax.TaxAmount = calculateTaxRequest.GrossAmount * calculatedTax.TaxPercentage;
                            
                            _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(CalculateTaxAsync)} tax amount is : {calculatedTax.TaxAmount:n}."));

                            calculatedTax.NettAmount = calculateTaxRequest.GrossAmount * (1 - calculatedTax.TaxPercentage);
                            
                            _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(CalculateTaxAsync)} total nett amount is : {calculatedTax.NettAmount:n}."));

                            calculatedTax.GrossAmount = calculateTaxRequest.GrossAmount;
                            var postalCodeDetails = await _inMemoryTaxRepository.GetPostalCodeByIdAsync(calculateTaxRequest.PostalCodeId ?? 0);
                            var taxTypeDetails = await _inMemoryTaxRepository.GetTaxTypeByIdAsync(taxType);
                            if (postalCodeDetails != null)
                                calculatedTax.PostalCode = postalCodeDetails.Code;

                            if (taxTypeDetails != null)
                                calculatedTax.TaxType = taxTypeDetails.TaxTypeName;

                             break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(CalculateTaxAsync)} - {ex.Message}"));

                throw new Exception(ex.Message);
            }
            return calculatedTax;
        }
    }
}
