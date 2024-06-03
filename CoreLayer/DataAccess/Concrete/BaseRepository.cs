using CoreLayer.DataAccess.Abstract;
using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreLayer.DataAccess.Concrete
{

    public class BaseRepository<T, TContext> : IBaseRepository<T>
        where T : BaseEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(T entity)
        {
            using (TContext context = new TContext())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (TContext context = new TContext())
            {
                entity.Delete = entity.Delete == 0 ? entity.Id : 0;
                entity.LastUpdateDate = DateTime.Now;
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void HardDelete(T entity)
        {
            using (TContext context = new TContext())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (TContext context = new TContext())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            using (TContext context = new TContext())
            {
                if (filter == null)
                {
                    return context.Set<T>().ToList();
                }
                else
                {
                    return context.Set<T>().Where(filter).ToList();
                }
            }
        }

        public T GetById(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<T>().FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
