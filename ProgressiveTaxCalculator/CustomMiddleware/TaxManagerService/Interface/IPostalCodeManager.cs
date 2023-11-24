using ProgressiveTaxCalculator.Model.Entities;
using ProgressiveTaxCalculator.Model.Objects;

namespace ProgressiveTaxCalculator.CustomMiddleware.TaxManagerService.Interface
{
    public interface IPostalCodeManager
    {
        Task<List<PostalCodeResponse>> GetPostalCodesAsync();
    }
}
