﻿using ProgressiveTaxCalculator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Model.Objects
{
    /// <summary>
    /// This is the global tax salary calculation request.
    /// </summary>
    public class TaxSalaryRequest
    {
        public int? PostalCodeId { get; set; }
        public decimal? GrossAmount { get; set; }
        public TaxSalaryRequest(int? postalCodeId, decimal? grossAmount) 
        {
            if (postalCodeId <= 0)
                throw new ArgumentOutOfRangeException("Postal code must be grater than 0.");

            if (grossAmount <= 0)
                throw new ArgumentOutOfRangeException("Gross amount must be grater than 0.");

            PostalCodeId = postalCodeId;
            GrossAmount = grossAmount;
        }
    }
}
