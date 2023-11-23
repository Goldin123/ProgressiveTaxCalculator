using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Model.Entities
{
    //Foreign keys https://github.com/dotnet/efcore/issues/2166
    /// <summary>
    /// This is the main tax type selection, currently defaulted to Progressive, Flat Value, Flat Rate.
    /// </summary>
    public class TaxType
    {

        [Key]
        public int? Id { get; set; }
        public string? TaxTypeName { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
