using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Model.Entities
{
    public class TaxCalculated
    {
        public int? Id { get; set; }
        public int? TaxTableId { get; set; }
        public int? TaxTypeId { get; set; }
        public int? PostalCodeId { get; set; }
        public int? TaxTermId { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? TaxPercentage { get; set; }
        public decimal? NettAmount { get; set; }
        public DateTime? DateAdded { get; set; }

    }
}
