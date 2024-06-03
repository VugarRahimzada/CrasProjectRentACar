using CoreLayer.Results.Abstract;
using EntityLayer.Concrete.DTOs.TestomonialDTOs;

namespace BusinessLayer.Abstract
{
    public interface ITestomonialService
    {
        IResult Add(TestomonialCreateDto entity);
        IResult Update(TestomonialUpdateDto entity);
        IResult Delete(int id);
        IResult HardDelete(int id);
        IDataResult<List<TestomonialReadDto>> GetAll();
        IDataResult<List<TestomonialReadActiveDto>> GetAllActive();
        IDataResult<TestomonialReadDto> GetById(int id);
    }
}
