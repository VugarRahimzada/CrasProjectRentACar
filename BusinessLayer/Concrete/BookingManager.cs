using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete.ErrorResult;
using CoreLayer.Results.Concrete.SuccessResult;
using CoreLayer.Validation;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete.DTOs.BookingDTOs;
using EntityLayer.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Net;

namespace BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;
        private readonly IMapper _mapper;
        private readonly IValidator<Booking> _validator;
        private readonly ICarDal _carDal;

        public BookingManager(IBookingDal bookingDal, IMapper mapper, IValidator<Booking> validator, ICarDal carDal)
        {
            _bookingDal = bookingDal;
            _mapper = mapper;
            _validator = validator;
            _carDal = carDal;
        }

        public IResult Add(BookingCreateDto entity)
        {
            var value = _carDal.GetById(entity.CarId);
            var booking = _mapper.Map<Booking>(entity);
            var validationResult = ValidationTool.Validate(booking, _validator);
            if (validationResult != null)
            {
                return validationResult;
            }

            _bookingDal.Add(booking);
            if (value.IsRented==false)
            {
            _carDal.CarRented(value);
            }
            else
            {
            return new ErrorResult(HttpStatusCode.Created, Messages.CAR_ALREADY_RENTED);

            }
            return new SuccessResult(HttpStatusCode.Created, Messages.SUCCESFULLY_ADDED);
        }

        public IResult Delete(int id)
        {
            var value = _bookingDal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _bookingDal.Delete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }

        public IResult HardDelete(int id)
        {
            var value = _bookingDal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _bookingDal.HardDelete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }

        public IResult Update(BookingUpdateDto entity)
        {
            var value = _bookingDal.GetById(entity.Id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _bookingDal.Update(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_UPDATE);
        }

        public IDataResult<List<BookingReadDto>> GetAll()
        {
            var bookings = _bookingDal.GetAll();
            var bookingDtos = _mapper.Map<List<BookingReadDto>>(bookings);

            if (bookingDtos == null || bookingDtos.Count == 0)
            {
                return new ErrorDataResult<List<BookingReadDto>>(bookingDtos, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<List<BookingReadDto>>(bookingDtos, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }
        public IDataResult<List<BookingReadActiveDto>> GetAllActive()
        {
            var bookings = _bookingDal.GetAllWithCar();
            var bookingDtos = _mapper.Map<List<BookingReadActiveDto>>(bookings);

            if (bookingDtos == null || bookingDtos.Count == 0)
            {
                return new ErrorDataResult<List<BookingReadActiveDto>>(bookingDtos, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<List<BookingReadActiveDto>>(bookingDtos, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

        public IDataResult<BookingReadDto> GetById(int id)
        {
            var booking = _bookingDal.GetById(id);
            var bookingDto = _mapper.Map<BookingReadDto>(booking);

            if (bookingDto == null)
            {
                return new ErrorDataResult<BookingReadDto>(bookingDto, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<BookingReadDto>(bookingDto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }





        public IDataResult<List<BookingConfirmationDto>> GetConfirmationList()
        {

            var bookings = _bookingDal.GetAllWaitingWithCar();
            var bookingDtos = _mapper.Map<List<BookingConfirmationDto>>(bookings);

            if (bookingDtos == null || bookingDtos.Count == 0)
            {
                return new ErrorDataResult<List<BookingConfirmationDto>>(bookingDtos, HttpStatusCode.NotFound, Messages.DIDNT_HAVE_WAITING_CAR);
            }
            return new SuccessDataResult<List<BookingConfirmationDto>>(bookingDtos, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

        public IResult ConfirmationbyId(int Id)
        {
            var value = GetById(Id);

            if (value == null)
            {
                return new SuccessResult(HttpStatusCode.NotFound, Messages.DIDNT_HAVE_WAITING_CAR);
            }

            _bookingDal.ConfirmationbyId(Id);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_UPDATE);
        }

        public IResult ConfirmationAll()
        {
            var value = GetConfirmationList();
            if (value == null)
            {
                return new SuccessResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }

            _bookingDal.ConfirmationAll();
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_UPDATE);

        }
    }
}
