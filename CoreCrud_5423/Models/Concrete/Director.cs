using CoreCrud_5423.Models.Abstract;
using System;
using System.Collections.Generic;

namespace CoreCrud_5423.Models.Concrete
{
    public class Director : BaseEntity
    {
        
        // bir sınıfın içinde başka sınıfın elemanlarını koleksiyon yapısını taşıyorsam ctorda çağırayım
        public Director()
        {
            Movies = new List<Movie>();
        }
        public string FirtsName { get; set; }
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }  // nullable

        public string FullName => FirtsName + " " + LastName;

        // navigation property

        // 1 yönetmenin çokça filmi olabilir.
        public virtual List<Movie> Movies { get; set; }


    }
}