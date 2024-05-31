using CoreLayer.Results.Abstract;
using EntityLayer.Concrete.DTOs.FuelDTOs;

namespace BusinessLayer.Abstract
{
    public interface IFuelService
    {
        IResult Add(FuelCreateDto entity);
        IResult Update(FuelUpdateDto entity);
        IResult Delete(int id);
        IResult HardDelete(int id);
        IDataResult<List<FuelReadDto>> GetAll();
        IDataResult<FuelReadDto> GetById(int id);
    }
}
