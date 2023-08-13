using System;
using System.Collections.Generic;

namespace InvoiceApp.Models
{
    public class CreateInvoiceViewModel
    {
        public float totalPrice { get; set; }
        public string customer { get; set; }
        public int id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Invoice Invoice { get; set; }
        public InvoiceItem InvoiceItems   { get; set; }
        public List<item> AvailableItems { get; set; }
        public List<int> SelectedItemIds { get; set; }
    }
}