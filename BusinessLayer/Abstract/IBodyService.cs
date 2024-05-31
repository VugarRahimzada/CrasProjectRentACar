using CoreLayer.Results.Abstract;
using EntityLayer.Concrete.DTOs.BodyDTOs;

namespace BusinessLayer.Abstract
{
    public interface IBodyService
    {
        IResult Add(BodyCreateDto entity);
        IResult Update(BodyUpdateDto entity);
        IResult Delete(int id);
        IResult HardDelete(int id);
        IDataResult<List<BodyReadDto>> GetAll();
        IDataResult<BodyReadDto> GetById(int id);
    }
}
