using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Model.Entities
{
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
