using CoreCrud_5423.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud_5423.Models.Concrete
{
    public class Actor :BaseEntity
    {
        public Actor()
        {
            MovieActors = new List<MovieActor>();
        }
        public string FirtsName { get; set; }
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }  // nullable

        public string FullName => FirtsName + " " + LastName;

        // navigation prop

        // 1 oyuncunun çokça filmi vardır.

        public virtual List<MovieActor>  MovieActors { get; set; }
    }
}
