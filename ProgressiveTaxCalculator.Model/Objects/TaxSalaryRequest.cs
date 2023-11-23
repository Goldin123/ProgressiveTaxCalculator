using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Model.Objects
{
    public class TaxSalaryRequest
    {

        public string? PostalCode { get; set; }
        public decimal? GrossAmount { get; set; }
        public TaxSalaryRequest( string? postalCode, decimal? grossAmount) 
        {
            if (string.IsNullOrEmpty(postalCode)) 
                throw new ArgumentNullException("Please enter a postal code");

            if (grossAmount < 0)
                throw new ArgumentOutOfRangeException("Gross amount must be grater than 0.");

            PostalCode = postalCode;
            GrossAmount = grossAmount;
        }
    }
}
