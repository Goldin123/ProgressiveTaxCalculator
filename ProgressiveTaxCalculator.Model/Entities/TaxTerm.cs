using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Model.Entities
{
    /// <summary>
    /// This will represent weather the term is annual, monthly, bi-weekly, etc..
    /// </summary>
    public class TaxTerm
    {
        public int? Id { get; set; }
        public string? TaxTermName { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
