using CoreLayer.Results.Abstract;
using EntityLayer.Concrete.DTOs.DoorDTOs;

namespace BusinessLayer.Abstract
{
    public interface IDoorService
    {
        IResult Add(DoorCreateDto entity);
        IResult Update(DoorUpdateDto entity);
        IResult Delete(int id);
        IResult HardDelete(int id);
        IDataResult<List<DoorReadDto>> GetAll();
        IDataResult<DoorReadDto> GetById(int id);
    }
}
