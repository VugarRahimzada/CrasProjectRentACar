using CoreLayer.Results.Abstract;
using EntityLayer.Concrete.DTOs.TransmissionDTOs;

namespace BusinessLayer.Abstract
{
    public interface ITransmissionService
    {
        IResult Add(TransmissionCreateDto entity);
        IResult Update(TransmissionUpdateDto entity);
        IResult Delete(int id);
        IResult HardDelete(int id);
        IDataResult<List<TransmissionReadDto>> GetAll();
        IDataResult<TransmissionReadDto> GetById(int id);
    }
}
