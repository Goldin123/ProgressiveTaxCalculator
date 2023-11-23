using ProgressiveTaxCalculator.Model.Entities;

namespace ProgressiveTaxCalculator.Api.Features.GetPostalCodes.Interface
{
    public interface IApiGetPostalCodes
    {
        Task<List<PostalCode>> GetPostalCodes();
    }
}
