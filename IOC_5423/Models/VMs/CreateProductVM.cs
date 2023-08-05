using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOC_5423.Models.VMs
{
    public class CreateProductVM
    {
        // 1 TANE PRODUCRT NESNE

        public Product Product { get; set; }

        // TÜM KATEGORİLER
        public List<SelectListItem> Categories { get; set; }

        // tüm tedarikçilerimi

        public List<SelectListItem> Suppliers { get; set; }
    }
}
