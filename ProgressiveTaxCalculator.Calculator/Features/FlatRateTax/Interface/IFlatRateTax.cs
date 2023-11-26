using ProgressiveTaxCalculator.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Calculator.Features.FlatRateTax.Interface
{
    public interface IFlatRateTax
    {
        Task<CalculatedTaxResponse> CalculateTaxAsync(CalculateTaxRequest calculateTaxRequest, int taxType);
    }
}
