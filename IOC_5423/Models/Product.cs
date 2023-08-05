using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOC_5423.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        // navigation prop => bu sınıfn başka sınnıfarla olan ilişkisini veritabanı tarafında açıklamak için kullanılan proplar.

        public int? CategoryId { get; set; }  // ?  anlamı şudur --> buadaki property nullable olarak oluşur.

        public Category Category { get; set; }

        public int? SupplierId { get; set; }

        public  Supplier  Supplier { get; set; }

        // iki şekilde veri çekebilirim. LAZY LOADING ve EAGER LOADING 
        // Defaultta yukaradki gibi yazarsam EAGER yapar.
        // LAZY olmasını istersem VİRTUAL keyword eklenemli ve proxy paketi eklenemlidir.
        // 

    }
}
