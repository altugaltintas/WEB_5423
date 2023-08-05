using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using CoreCrud_5423.Infrastructure.Interfaces.Concrete;
using CoreCrud_5423.Models.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CoreCrud_5423.Views.Shared.Components.MovieWithDirectorTop
{
    public class MovieWithDirectorTopViewComponent : ViewComponent
    {
        //en çok filmi olan 3 yazarı alalım



        private readonly IDirector _dRepo;


            public MovieWithDirectorTopViewComponent(IDirector dRepo)
            {
                _dRepo = dRepo;
            }

        public IViewComponentResult Invoke()
        {


            List<Director> list = _dRepo.GetDefaults(a => a.IsActive).OrderByDescending(a => a.Movies.Where(a => a.IsActive).Count()).Take(3).ToList();
         
            return View(list);
        }
        



    }
}
