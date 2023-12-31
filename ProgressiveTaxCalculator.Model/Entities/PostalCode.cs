﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Model.Entities
{
    /// <summary>
    /// This represents the available postal codes linked the available tax type.
    /// </summary>
    public class PostalCode
    {
        [Key]
        public int? Id { get; set; }
        [ForeignKey(nameof(TaxType.Id))]
        public int? TaxTypeId { get; set; }
        public string? Code { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
