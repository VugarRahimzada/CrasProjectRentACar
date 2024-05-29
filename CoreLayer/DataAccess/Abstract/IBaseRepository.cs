using CoreLayer.Entities;
using System.Linq.Expressions;

namespace CoreLayer.DataAccess.Abstract
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void HardDelete(T entity);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null);
        //IEnumerable<T> GetActiveAll();
        T GetById(int id);
    }
}
