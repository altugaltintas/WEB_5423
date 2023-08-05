using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOC_5423.Infrastructure.Repositories.Abstract
{
    // Generic Type kullanmış olduk. T sınıfı şuan bu interface içinde belli değil ama implemeete edileceği yerde hangi sınıf seçilirse o sınıf için aşağıdaki metotlar şekilllendirebilir olmuş olacak.
    // Generic Typlar sınıf , interface , koleksiyon yapıları vb. kullanılabilinir..
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        int Save();
        IList<T> GetAll();

    }
}
