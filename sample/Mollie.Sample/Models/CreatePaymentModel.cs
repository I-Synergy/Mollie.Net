using System.ComponentModel.DataAnnotations;
using Mollie.Models;
using Mollie.Sample.Framework.Validators;

namespace Mollie.Sample.Models {
    public class CreatePaymentModel {
        [Required]
        [Range(0.01, 1000, ErrorMessage = "Please enter an amount between 0.01 and 1000")]
        [RegularExpression(@"\d+(\.\d{2})?", ErrorMessage = "Please enter an amount with two decimal places")]
        public decimal Amount { get; set; }

        [Required]
        [StaticStringList(typeof(Currency))]
        public string Currency { get; set; }

        [Required]
        public string Description { get; set; }
    }
}