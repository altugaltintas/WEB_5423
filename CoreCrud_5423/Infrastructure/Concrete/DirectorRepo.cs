using CoreCrud_5423.Infrastructure.Abstract;
using CoreCrud_5423.Infrastructure.Interfaces.Concrete;
using CoreCrud_5423.Models.Concrete;
using CoreCrud_5423.Models.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud_5423.Infrastructure.Concrete
{
    public class DirectorRepo : BaseRepo<Director>,IDirector
    {
        public DirectorRepo(ProjectContext context) : base(context)
        {
        }

    } 
}
