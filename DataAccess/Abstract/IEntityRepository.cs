using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //generic constraint(kısıt)
    //class : referans tip olabilir demek
    //IEntity : IEntity veya IEntity implemente eden bir nesne olabilir
    //new() : new lenebilir nesne olmalı. IEntity new lenemez çünkü abstract (soyut) bir nesne 
    public interface IEntityRepository<T> where T : class,IEntity,new()
    
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        //her türlü filtre ile çağırılabilir ve filtresiz de çalışabilir                                               
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //List<T> GetAllByCategory(int CategoryId);
        //ilk iki satır
        //bu fonksiyonun yerine geçiyor
    }
}
