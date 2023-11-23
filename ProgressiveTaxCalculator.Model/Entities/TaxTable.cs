using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Model.Entities
{
    /// <summary>
    /// This defines the available tax percentage for each tax type linked to a postal code also the amount bracket levels.
    /// </summary>
    public class TaxTable
    {
        public int? Id { get; set; }
        public int? TaxTypeId { get; set; }
        public int? PostalCodeId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? TaxPercentage { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
