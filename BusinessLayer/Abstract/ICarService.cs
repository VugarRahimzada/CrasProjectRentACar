using CoreLayer.Results.Abstract;
using EntityLayer.Concrete.DTOs.CarDTOs;

namespace BusinessLayer.Abstract
{
    public interface ICarService
    {
        IResult Add(CarCreateDTO entity);
        IResult Update(CarUpdateDto entity);
        IResult Delete(int id);
        IResult HardDelete(int id);
        IDataResult<List<CarReadDto>> GetAll();
        IDataResult<List<CarReadActivDto>> GetAllActive();
        IDataResult<CarReadDto> GetById(int id);
    }
}
