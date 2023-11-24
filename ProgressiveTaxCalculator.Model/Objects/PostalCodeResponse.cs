using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Model.Objects
{
    public class PostalCodeResponse
    {
        public int? id { get; set; }
        public int? taxTypeId { get; set; }
        public string? code { get; set; }
        public string? name { get; set; }
        public string? taxTypeName { get; set; }
    }
}
