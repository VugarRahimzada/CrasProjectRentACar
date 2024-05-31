using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete.ErrorResult;
using CoreLayer.Results.Concrete.SuccessResult;
using CoreLayer.Validation;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete.DTOs.FuelDTOs;
using EntityLayer.Concrete.TableModels;
using FluentValidation;
using System.Net;

namespace BusinessLayer.Concrete
{
    public class FuelManager : IFuelService
    {
        private readonly IFuelDal _fuelDal;
        private readonly IMapper _mapper;
        private readonly IValidator<Fuel> _validator;

        public FuelManager(IFuelDal fuelDal, IMapper mapper, IValidator<Fuel> validator)
        {
            _fuelDal = fuelDal;
            _mapper = mapper;
            _validator = validator;
        }

        public IResult Add(FuelCreateDto entity)
        {
            var fuel = _mapper.Map<Fuel>(entity);
            var validationResult = ValidationTool.Validate(fuel, _validator);
            if (validationResult != null)
            {
                return validationResult;
            }

            _fuelDal.Add(fuel);
            return new SuccessResult(HttpStatusCode.Created, Messages.SUCCESFULLY_ADDED);
        }

        public IResult Delete(int id)
        {
            var value = _fuelDal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _fuelDal.Delete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }

        public IResult HardDelete(int id)
        {
            var value = _fuelDal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _fuelDal.HardDelete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }

        public IResult Update(FuelUpdateDto entity)
        {
            var value = _fuelDal.GetById(entity.Id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _mapper.Map(entity, value);
            _fuelDal.Update(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_UPDATE);
        }

        public IDataResult<List<FuelReadDto>> GetAll()
        {
            var fuels = _fuelDal.GetAll();
            var fuelDtos = _mapper.Map<List<FuelReadDto>>(fuels);

            if (fuelDtos == null || fuelDtos.Count == 0)
            {
                return new ErrorDataResult<List<FuelReadDto>>(fuelDtos, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<List<FuelReadDto>>(fuelDtos, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

        public IDataResult<FuelReadDto> GetById(int id)
        {
            var fuel = _fuelDal.GetById(id);
            var fuelDto = _mapper.Map<FuelReadDto>(fuel);

            if (fuelDto == null)
            {
                return new ErrorDataResult<FuelReadDto>(fuelDto, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<FuelReadDto>(fuelDto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }
    }
}
