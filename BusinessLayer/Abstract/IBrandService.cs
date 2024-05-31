using CoreLayer.Results.Abstract;
using EntityLayer.Concrete.DTOs.BrandDTOs;

namespace BusinessLayer.Abstract
{
    public interface IBrandService
    {
        IResult Add(BrandCreateDto entity);
        IResult Update(BrandUpdateDto entity);
        IResult Delete(int id);
        IResult HardDelete(int id);
        IDataResult<List<BrandReadDto>> GetAll();
        IDataResult<BrandReadDto> GetById(int id);
    }
}
