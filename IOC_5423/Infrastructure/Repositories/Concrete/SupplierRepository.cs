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
    public class SupplierRepository : IRepository<Supplier>
    {
        private readonly ProjectContext _context;

        public SupplierRepository(ProjectContext context)
        {
            _context = context;
        }

        public void Add(Supplier entity)
        {
            _context.Suppliers.Add(entity);
        }

        public IList<Supplier> GetAll()
        {
            return _context.Suppliers.Include(a => a.Products).ToList();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
