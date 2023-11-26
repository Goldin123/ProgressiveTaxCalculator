using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Model.Objects
{
    /// <summary>
    /// This represents the final calculated values.
    /// </summary>
    public class CalculatedTaxResponse
    {
        public decimal? GrossAmount { get; set; }
        public decimal? NettAmount { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? TaxPercentage { get; set; }
        public string? PostalCode { get; set; }
        public string? TaxType { get; set; }
        public CalculatedTaxResponse (decimal? grossAmount, decimal? nettAmount, decimal? taxPercentage, string? postalCode, string? taxType, decimal? taxAmount)
        {
            GrossAmount = grossAmount;
            NettAmount = nettAmount;
            TaxPercentage = taxPercentage;
            PostalCode = postalCode;
            TaxType = taxType;
            TaxAmount = taxAmount;
        }
    }

    public class CalculatedTaxApiResponse
    {
        public decimal? grossAmount { get; set; }
        public decimal? nettAmount { get; set; }
        public decimal? taxAmount { get; set; }
        public decimal? taxPercentage { get; set; }
        public string? postalCode { get; set; }
        public string? taxType { get; set; }
        
    }
}
