namespace InvoiceApp.Models
{
    public class InvoiceItem
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        
        public int ItemId { get; set; }
        public item Item { get; set; }
    }

}