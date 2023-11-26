using ProgressiveTaxCalculator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Model.Objects
{
    public class CalculateTaxRequest
    {
        public int? PostalCodeId { get; set; }
        public decimal? GrossAmount { get; set; }
        public List<TaxTable>? TaxTables { get; set; }
        public CalculateTaxRequest(int? postalCodeId, decimal? grossAmount)
        {
            if (postalCodeId < 0)
                throw new ArgumentNullException("Postal code must be grater than 0.");

            if (grossAmount < 0)
                throw new ArgumentOutOfRangeException("Gross amount must be grater than 0.");

            PostalCodeId = postalCodeId;
            GrossAmount = grossAmount;
            TaxTables = new List<TaxTable>();
        }
    }
}
