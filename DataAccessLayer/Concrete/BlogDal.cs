using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class BlogDal : BaseRepository<Blog, AppDbContext>, IBlogDal
    {
        private readonly AppDbContext _appDbContext;

        public BlogDal(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void IncreesCommentCounta(int id)
        {
            _appDbContext.Blogs.Find(id).CommentCounta++;

            _appDbContext.SaveChanges();
        }
        public void DecreaseCommentCounta(int id)
        {
            _appDbContext.Blogs.Find(id).CommentCounta--;

            _appDbContext.SaveChanges();
        }

        public IEnumerable<Blog> GetAllWithComments()
        {
           return _appDbContext.Blogs.Where(x=>x.Delete==0).Include(x=>x.Comments.Where(x=>x.Delete==0)).ToList();
        }

    }
}
