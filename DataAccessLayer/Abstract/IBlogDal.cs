using CoreLayer.DataAccess.Abstract;
using EntityLayer.Concrete.TableModels;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal :IBaseRepository<Blog>
    {
        void IncreaseCommentCount(int id);
        void DecreaseCommentCounta(int id);
        IEnumerable<Blog> GetAllWithComments();
    }
}
