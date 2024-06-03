using CoreLayer.Results.Abstract;
using EntityLayer.Concrete.DTOs.AboutDTOs;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        IResult Add(AboutCreateDto entity);
        IResult Update(AboutUpdateDto entity);
        IResult Delete(int id);
        IResult HardDelete(int id);
        IDataResult<List<AboutReadDto>> GetAll();
        IDataResult<AboutReadDto> GetById(int id);
    }
}
