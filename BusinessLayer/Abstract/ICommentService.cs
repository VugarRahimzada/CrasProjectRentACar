using CoreLayer.Results.Abstract;
using EntityLayer.Concrete.DTOs.CommentDTOs;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        IResult Add(CommentCreateDto entity);
        IResult Delete(int id);
        IResult HardDelete(int id);
        IDataResult<List<CommentReadDto>> GetAll();
        IDataResult<List<CommentReadActiveDto>> GetAllActive();
        IDataResult<CommentReadDto> GetById(int id);
        IDataResult<List<CommentReadActiveDto>> GetCommentsByBlogId(int id);
    }
}
