using CoreLayer.Results.Abstract;
using EntityLayer.Concrete.DTOs.BlogDTOs;
using EntityLayer.Concrete.TableModels;


namespace BusinessLayer.Abstract
{
    public interface IBlogService 
    {
        IResult Add(BlogCreateDto entity);
        IResult Update(BlogUpdateDto entity);
        IResult Delete(int id);
        IResult HardDelete(int id);
        IDataResult<List<BlogReadDto>> GetAll();
        IDataResult<List<BlogReadActivDto>> GetAllActive();
        IDataResult<BlogReadDto> GetById(int id);
    }
}
