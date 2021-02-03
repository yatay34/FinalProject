using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DaraAccess.Abstract
{
    //Generic constraint(kısıt) -- 
    //class : referans tip (örn: int olamaz)
    //IEntity : IEntity veya IEntity implemente eden bir nesne
    // -- db class-larımız ile sınırlıyoruz.
    //new() : new-lenebilir olmalı --interface değil class
    // >>>>db nesneleri ile çalışan bir repository oldu

    public interface IEntityRepository<T> where T:class,IEntity,new() 
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity); 
    }
}
