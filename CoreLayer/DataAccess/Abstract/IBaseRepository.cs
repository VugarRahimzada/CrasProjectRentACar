using CoreLayer.Entities;

namespace CoreLayer.DataAccess.Abstract
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void HardDelete(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetActiveAll();
        T GetById(int id);
    }
}
