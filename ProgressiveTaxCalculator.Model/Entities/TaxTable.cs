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
    /// This defines the available tax percentage for each tax type linked to a postal code also the amount bracket levels.
    /// </summary>
    public class TaxTable
    {
        [Key]
        public int? Id { get; set; }
        [ForeignKey(nameof(TaxType.Id))]
        public int? TaxTypeId { get; set; }
        [ForeignKey(nameof(PostalCode.Id))]
        public int? PostalCodeId { get; set; }
        [ForeignKey(nameof(TaxTerm.Id))]
        public int? TaxTermId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? TaxPercentage { get; set; }
        public bool? UsePercentage { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
