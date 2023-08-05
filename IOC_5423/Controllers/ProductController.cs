using IOC_5423.Infrastructure.Repositories.Abstract;
using IOC_5423.Models;
using IOC_5423.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOC_5423.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Category> _crepo;
        private readonly IRepository<Supplier> _srepo;
        private readonly IRepository<Product> _prepo;

        public ProductController(IRepository<Category> crepo,IRepository<Supplier> srepo,IRepository<Product> prepo)
        {
            _crepo = crepo;
           _srepo = srepo;
            _prepo = prepo;
        }

        [HttpGet]  // defaultta zaten httpget olarak kabul eder.
        public IActionResult Create()
        {
            var vm = new CreateProductVM()
            {
             Categories=_crepo.GetAll().Select(a=> new SelectListItem { Text=a.Name, Value=a.CategoryId.ToString() }).ToList(),
             Suppliers=_srepo.GetAll().Select(a=> new SelectListItem { Text=a.CompanyName,Value=a.SupplierId.ToString()}).ToList(),
             Product=new Product()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _prepo.Add(product);
            int sonuc=_prepo.Save();
            if (sonuc > 0) return RedirectToAction("List");
            else return NotFound();
        }



        public IActionResult List()
        {
            return View(_prepo.GetAll());

        }






    }
}
