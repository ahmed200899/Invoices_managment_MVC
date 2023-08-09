using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer name is required.")]
        public string Customer { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; }
    }
}
