using CoreLayer.DataAccess.Abstract;
using EntityLayer.Concrete.TableModels;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDal :IBaseRepository<Comment>
    {
        List<Comment> GetCommentsByBlogId(int Id);
    }
}
