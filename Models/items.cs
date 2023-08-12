using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.Models
{
    public class item
    {
        public int Id { get; set; }

        [Display(Name = "Item Name")]
        public string Itemname { get; set; }
        
        [Display(Name = "Item Price")] 
        public float itemprice { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }

    }
}