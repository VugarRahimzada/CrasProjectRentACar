using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Concrete.TableModels;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete
{
    public class CommentDal : BaseRepository<Comment, AppDbContext>, ICommentDal
    {
        private readonly AppDbContext _appDbContext;

        public CommentDal(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        List<Comment> ICommentDal.GetCommentsByBlogId(int Id)
        {
            var value = _appDbContext.Comments.Where(x=>x.BlogId==Id).Where(x=>x.Delete==0).ToList();
            return value;
        }
    }
}
