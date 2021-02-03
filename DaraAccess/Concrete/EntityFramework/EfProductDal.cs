using DaraAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DaraAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposibale Pattern implementation of c# //perfrmans için using kullanıyoruz.
            using (NorthwindContext context = new NorthwindContext()) 
            { 
                //git veri kaynağından benim gönderdiğim Product'ta bir nesneyi eşleştir.
                //yeni ekleme olduğu için eşleştirmeyecek
                var addedEntity = context.Entry(entity); //ilişkilendirir
                addedEntity.State = EntityState.Added;   //ekleme old belirtir
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) 
            {  
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;   
                context.SaveChanges();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return (filter == null)
                   ? context.Set<Product>().ToList() 
                   : context.Set<Product>().Where(filter).ToList();
            }
        }

    }
}
