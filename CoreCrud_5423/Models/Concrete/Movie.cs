using CoreCrud_5423.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud_5423.Models.Concrete
{
    public class Movie : BaseEntity
    {
        //Bu sınıftan bir instance alındığında listenin varlığı olsun.ctorda yapıyorum
        public Movie()
        {
            MovieActors = new List<MovieActor>();//movie instance alındığında kendi içinde list yapısı oluşmuş olarak gelir.
        }

        public string Name { get; set; }
        public DateTime PublishDate { get; set; }

        //navigation property

        //1 filmin 1 yönetmeni vardır

        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }

        //1 filmin çokça oyuncusu vardır
        public virtual List<MovieActor> MovieActors { get; set; }//virtual keywordü eklediğimde LAZY LOADING yağılmış olur. yeterli gemez. Mic.Efcore.Proxy paketi indirilmeli
    }
}
