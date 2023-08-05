using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreCrud_5423.Infrastructure.Interfaces.Abstract
{
   public interface IBaseRepo<T> where T: class
    {
        // CRUD OPERASYON = CREATE READ UPDATE DELETE 
        void Create(T entity);

        void Update(T entity);
        void Delete(T entity);

        T GetDefault(Expression<Func<T,bool>> expression);    // tek bir T nesnesini bir expression sonucu döner

        List<T> GetDefaults(Expression<Func<T,bool>> expression);   // expressiona uyan tüm T tipindeki nesneleri getirir.

        // Bir tablo üzerinden expression iismli parametreyle önce eleme yapıp , koşulu sağlayan nesneleri alırız.
        // selector isimli  parametre ile tam olarak T tipini değil , bir dto yada vm döndüreceksek elimizdeki T ile diğer tipi işler bir TResult döndürmüş oluruz.
        // defaultta null bırakılan yani sıralanmayan elimizdeki sonuç kümesini istersek orderBy isimli paraöetre ile sıralayabiliriz.

        List<TResult> GetByDefaults<TResult>( 
                                            Expression<Func<T,TResult>> selector,                  // select seçim
                                            Expression<Func<T,bool>> expression,                   // filtreleme - where
                                            Func<IQueryable<T>,IOrderedQueryable<T>> orderBy=null  // sıralama - order by
                                            );




    }
}
