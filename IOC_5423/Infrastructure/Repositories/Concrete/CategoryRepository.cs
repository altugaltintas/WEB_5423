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
    public class CategoryRepository : IRepository<Category>
    {
        private readonly ProjectContext _context;

        public CategoryRepository(ProjectContext context)
        {
            _context = context;
        }


        public void Add(Category entity)
        {
            _context.Categories.Add(entity);
        }

        public IList<Category> GetAll()
        {
            return _context.Categories.Include(a => a.Products).ToList();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
