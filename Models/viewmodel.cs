using System.Collections.Generic;

namespace InvoiceApp.Models
{
    public class viewmodel
    {
        public Invoice invoice { get; set; }
        public List<InvoiceItem> invoiceiteme { get; set; }
        public List<item> items {get; set; }
        public int  SelectedValue { get; set; }
    }
}