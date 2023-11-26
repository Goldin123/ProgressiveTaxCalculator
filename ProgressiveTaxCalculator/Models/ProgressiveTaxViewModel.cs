using ProgressiveTaxCalculator.Model.Objects;
using System.ComponentModel.DataAnnotations;

namespace ProgressiveTaxCalculator.Models
{
    public class ProgressiveTaxViewModel
    {
        [Required(ErrorMessage ="Please select a postal code.")]
        public int PostalCodeId { get; set; }
        public List<PostalCodeResponse>? PostalCodes { get; set; }

        [Required(ErrorMessage ="Please enter an amount.")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a non-negative number.")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal GrossAmount { get; set; }
    }
}
