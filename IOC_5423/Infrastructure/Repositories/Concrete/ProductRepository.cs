using IOC_5423.Infrastructure.Repositories.Abstract;
using IOC_5423.Models;
using IOC_5423.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOC_5423.Infrastructure.Repositories.Concrete
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ProjectContext _context;

        public ProductRepository(ProjectContext context)
        {
            _context = context;
        }

        public void Add(Product entity)
        {
            _context.Products.Add(entity);
        }

        public IList<Product> GetAll()
        {
          return  _context.Products.Include(a => a.Category).Include(a => a.Supplier).ToList();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
