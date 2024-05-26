using CoreLayer.DataAccess.Abstract;
using EntityLayer.Concrete.TableModels;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal :IBaseRepository<Blog>
    {
    }
}
