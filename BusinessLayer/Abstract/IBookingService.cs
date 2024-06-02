using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete.SuccessResult;
using EntityLayer.Concrete.DTOs.BookingDTOs;
using EntityLayer.Concrete.DTOs.CarDTOs;
using System.Net;

namespace BusinessLayer.Abstract
{
    public interface IBookingService 
    {
        IResult Add(BookingCreateDto entity);
        IResult Update(BookingUpdateDto entity);
        IResult Delete(int id);
        IResult HardDelete(int id);
        IDataResult<List<BookingReadDto>> GetAll();
        IDataResult<List<BookingReadActiveDto>> GetAllActive();
        IDataResult<BookingReadDto> GetById(int id);


        IDataResult<List<BookingConfirmationDto>> GetConfirmationList();
        IResult ConfirmationAll();
        IResult ConfirmationbyId(int Id);
    }
}
