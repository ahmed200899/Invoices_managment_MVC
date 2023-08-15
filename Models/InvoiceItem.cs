using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.Models
{
    public class InvoiceItem
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public int Amount { get; set; }

        public int ItemId { get; set; }
        public item Item { get; set; }


    }

}