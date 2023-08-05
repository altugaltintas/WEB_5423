using System.Collections.Generic;

namespace IOC_5423.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        // navigation prop

        public ICollection<Product> Products { get; set; }



    }
}