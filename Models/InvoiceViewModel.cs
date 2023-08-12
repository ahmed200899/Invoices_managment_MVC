using System.Collections.Generic;

namespace InvoiceApp.Models
{
    public class CreateInvoiceViewModel
    {
        public Invoice Invoice { get; set; }
        public List<item> AvailableItems { get; set; }
        public List<int> SelectedItemIds { get; set; }
    }
}