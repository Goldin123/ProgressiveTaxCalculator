using ProgressiveTaxCalculator.Model.Objects;

namespace ProgressiveTaxCalculator.Api.Features.CalculateTax.Interface
{
    public interface IApiCalculateSalaryTax
    {
        Task<CalculatedTaxResponse> CalculateSalaryTaxAsync(TaxSalaryRequest taxSalaryRequest);
    }
}
