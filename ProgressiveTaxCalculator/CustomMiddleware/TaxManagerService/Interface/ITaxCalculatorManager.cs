using ProgressiveTaxCalculator.Models;

namespace ProgressiveTaxCalculator.CustomMiddleware.TaxManagerService.Interface
{
    public interface ITaxCalculatorManager
    {
        Task<Tuple<string, bool>> CalculateTaxAsync(ProgressiveTaxViewModel progressiveTaxViewModel);
    }
}
