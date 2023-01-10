using Microsoft.Build.Framework;
using System.ComponentModel;

namespace MyFirstWebApplication.Models
{
    public class ApartmentModel
    {

        [DisplayName("Apartment Number")]
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("MonthNumber")]
        public int MonthId { get; set; }
        [DisplayName("Charges")]
        public decimal MonthSaldo { get; set; } = 0;

        [DisplayName("Saldo")]
        [Required]
        public decimal Saldo { get; set; } = 0;

        [DisplayName("Payment")]
        public decimal Paid { get; set; } = 0;

        [DisplayName("Remaining")]
        public decimal Left { get; set; }

        [Required]
        [DisplayName("Year")]
        public int Year { get; set; }
        public string? Month { get; set; }
    }
}
