using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.BaseMessage;
using CoreLayer.Extension;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete.ErrorResult;
using CoreLayer.Results.Concrete.SuccessResult;
using CoreLayer.Validation;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete.DTOs.CarDTOs;
using EntityLayer.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using System.Reflection.Metadata;

namespace BusinessLayer.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IValidator<Car> _validator;

        public CarManager(ICarDal carDal, IMapper mapper, IWebHostEnvironment webHostEnvironment, IValidator<Car> validator)
        {
            _carDal = carDal;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _validator = validator;
        }

        public IResult Add(CarCreateDTO entity)
        {

          
            var car = _mapper.Map<Car>(entity);

            var validationResult = ValidationTool.Validate<Car>(car, _validator);
            if (validationResult != null)
            {
                return validationResult;
            }

            if (!_carDal.Check(car))
            {
                return new ErrorResult(HttpStatusCode.NotFound, Messages.ID_NOT_VALID);
            }

            car.PhotoPath = PictureHelper.UploadImage(entity.PhotoPath, _webHostEnvironment.WebRootPath);
            _carDal.Add(car);
            return new SuccessResult(HttpStatusCode.Created, Messages.SUCCESFULLY_ADDED);

        }

        public IResult Delete(int id)
        {
            var value = _carDal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _carDal.Delete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }
        public IResult HardDelete(int id)
        {
            var value = _carDal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _carDal.HardDelete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }

        public IResult Update(CarUpdateDto entity)
        {
            var existingCar = _carDal.GetById(entity.Id);

            if (existingCar == null)
            {
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }

            var car = _mapper.Map<Car>(entity);

            var validationResult = ValidationTool.Validate<Car>(car, _validator);
            if (validationResult != null)
            {
                return validationResult;
            }

            if (entity.PhotoPath != null)
            {
                car.PhotoPath = PictureHelper.UploadImage(entity.PhotoPath, _webHostEnvironment.WebRootPath);
            }
            else
            {
                car.PhotoPath = existingCar.PhotoPath;
            }


            _carDal.Update(car);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_UPDATE);
        }

        public IDataResult<List<CarReadDto>> GetAll()
        {
            var car = _carDal.GetAllWithPart();
            var cardto = _mapper.Map<List<CarReadDto>>(car);

            if (cardto == null || cardto.Count == 0)
            {
                return new ErrorDataResult<List<CarReadDto>>(cardto, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<List<CarReadDto>>(cardto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

        public IDataResult<List<CarReadActivDto>> GetAllActive()
        {
            var car = _carDal.GetAllWithPart(x=>x.Delete==0);
            var cardto = _mapper.Map<List<CarReadActivDto>>(car);

            if (cardto == null || cardto.Count == 0)
            {
                return new ErrorDataResult<List<CarReadActivDto>>(cardto, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<List<CarReadActivDto>>(cardto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

        public IDataResult<CarReadDto> GetById(int id)
        {
            var car = _carDal.GetById(id);
            var cardto = _mapper.Map<CarReadDto>(car);

            if (cardto == null)
            {
                return new ErrorDataResult<CarReadDto>(cardto, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<CarReadDto>(cardto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

    }
}
