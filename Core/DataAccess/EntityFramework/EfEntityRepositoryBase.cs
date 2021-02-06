using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext>: IEntityRepository<TEntity>

        where TEntity: class, IEntity, new()
        where TContext: DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposibale Pattern implementation of c# //perfrmans için using kullanıyoruz.
            using (TContext context = new TContext())
            {
                //git veri kaynağından benim gönderdiğim Product'ta bir nesneyi eşleştir.
                //yeni ekleme olduğu için eşleştirmeyecek
                var addedEntity = context.Entry(entity); //ilişkilendirir
                addedEntity.State = EntityState.Added;   //ekleme old belirtir
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return (filter == null)
                   ? context.Set<TEntity>().ToList()
                   : context.Set<TEntity>().Where(filter).ToList();
            }
        }

    }
}
