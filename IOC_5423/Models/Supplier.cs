using System.Collections.Generic;

namespace IOC_5423.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        public string CompanyName { get; set; }

        // navigation prop

        public ICollection<Product> Products { get; set; }
    }
}