using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace InvoiceApp.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer name is required.")]
        public string Customer { get; set; }

        public int Amount { get; set; }
        public float TotalPrice { get; set; }


        [Display(Name = "Invoice Date")]
        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
