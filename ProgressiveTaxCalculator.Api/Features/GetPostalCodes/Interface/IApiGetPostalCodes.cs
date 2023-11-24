using ProgressiveTaxCalculator.Model.Entities;
using ProgressiveTaxCalculator.Model.Objects;

namespace ProgressiveTaxCalculator.Api.Features.GetPostalCodes.Interface
{
    public interface IApiGetPostalCodes
    {
        Task<List<PostalCodeResponse>> GetPostalCodes();
    }
}
