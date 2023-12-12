using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Model.Entities
{
    /// <summary>
    /// This holds the history/audit of all calculated values.
    /// </summary>
    public class TaxCalculated
    {
        [Key]
        public int? Id { get; set; }
        [ForeignKey(nameof(TaxTable.Id))]
        public int? TaxTableId { get; set; }
        [ForeignKey(nameof(TaxType.Id))]
        public int? TaxTypeId { get; set; }
        [ForeignKey(nameof(PostalCode.Id))]
        public int? PostalCodeId { get; set; }
        [ForeignKey(nameof(TaxTerm.Id))]
        public int? TaxTermId { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? TaxPercentage { get; set; }
        public decimal? NettAmount { get; set; }
        public DateTime? DateAdded { get; set; }

    }
}
