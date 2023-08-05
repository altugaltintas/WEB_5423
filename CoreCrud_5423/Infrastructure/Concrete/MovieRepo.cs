using CoreCrud_5423.Infrastructure.Abstract;
using CoreCrud_5423.Infrastructure.Interfaces.Concrete;
using CoreCrud_5423.Models.Concrete;
using CoreCrud_5423.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud_5423.Infrastructure.Concrete
{
    public class MovieRepo : BaseRepo<Movie>,IMovieRepo
    {
        public MovieRepo(ProjectContext context) : base(context)
        {
        }

      
    }
}
