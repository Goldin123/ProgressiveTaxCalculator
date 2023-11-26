using ProgressiveTaxCalculator.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Calculator.Features.FlatValueTax.Interface
{
    public interface IFlatValueTax
    {
        Task<CalculatedTaxResponse> CalculateTaxAsync(CalculateTaxRequest calculateTaxRequest, int taxType);
    }
}
