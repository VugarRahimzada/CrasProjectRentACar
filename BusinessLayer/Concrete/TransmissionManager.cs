using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete.ErrorResult;
using CoreLayer.Results.Concrete.SuccessResult;
using CoreLayer.Validation;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete.DTOs.TransmissionDTOs;
using EntityLayer.Concrete.TableModels;
using FluentValidation;
using System.Net;

namespace BusinessLayer.Concrete
{
    public class TransmissionManager : ITransmissionService
    {
        private readonly ITransmissionDal _transmissionDal;
        private readonly IMapper _mapper;
        private readonly IValidator<Transmission> _validator;

        public TransmissionManager(ITransmissionDal transmissionDal, IMapper mapper, IValidator<Transmission> validator)
        {
            _transmissionDal = transmissionDal;
            _mapper = mapper;
            _validator = validator;
        }

        public IResult Add(TransmissionCreateDto entity)
        {
            var transmission = _mapper.Map<Transmission>(entity);
            var validationResult = ValidationTool.Validate(transmission, _validator);
            if (validationResult != null)
            {
                return validationResult;
            }

            _transmissionDal.Add(transmission);
            return new SuccessResult(HttpStatusCode.Created, Messages.SUCCESFULLY_ADDED);
        }

        public IResult Delete(int id)
        {
            var value = _transmissionDal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _transmissionDal.Delete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }

        public IResult HardDelete(int id)
        {
            var value = _transmissionDal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _transmissionDal.HardDelete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }

        public IResult Update(TransmissionUpdateDto entity)
        {
            var value = _transmissionDal.GetById(entity.Id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _mapper.Map(entity, value);
            _transmissionDal.Update(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_UPDATE);
        }

        public IDataResult<List<TransmissionReadDto>> GetAll()
        {
            var transmissions = _transmissionDal.GetAll();
            var transmissionDtos = _mapper.Map<List<TransmissionReadDto>>(transmissions);

            if (transmissionDtos == null || transmissionDtos.Count == 0)
            {
                return new ErrorDataResult<List<TransmissionReadDto>>(transmissionDtos, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<List<TransmissionReadDto>>(transmissionDtos, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

        public IDataResult<TransmissionReadDto> GetById(int id)
        {
            var transmission = _transmissionDal.GetById(id);
            var transmissionDto = _mapper.Map<TransmissionReadDto>(transmission);

            if (transmissionDto == null)
            {
                return new ErrorDataResult<TransmissionReadDto>(transmissionDto, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<TransmissionReadDto>(transmissionDto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }
    }
}
