using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete.ErrorResult;
using CoreLayer.Results.Concrete.SuccessResult;
using CoreLayer.Validation;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete.DTOs.BodyDTOs;
using EntityLayer.Concrete.TableModels;
using FluentValidation;
using System.Net;

namespace BusinessLayer.Concrete
{

    public class BodyManager : IBodyService
    {
        private readonly IBodyDal _bodydal;
        private readonly IMapper _mapper;
        private readonly IValidator<Body> _validator;

        public BodyManager(IBodyDal bodydal, IMapper mapper, IValidator<Body> validator)
        {
            _bodydal = bodydal;
            _mapper = mapper;
            _validator = validator;
        }

        public IResult Add(BodyCreateDto entity)
        {
            var body = _mapper.Map<Body>(entity);
            var validationResult = ValidationTool.Validate(body, _validator);
            if (validationResult != null)
            {
                return validationResult;
            }

            _bodydal.Add(body);
            return new SuccessResult(HttpStatusCode.Created, Messages.SUCCESFULLY_ADDED);
        }

        public IResult Delete(int id)
        {
            var value = _bodydal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _bodydal.Delete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }

        public IResult HardDelete(int id)
        {
            var value = _bodydal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _bodydal.HardDelete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }

        public IResult Update(BodyUpdateDto entity)
        {
            var value = _bodydal.GetById(entity.Id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _bodydal.Update(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_UPDATE);
        }
        public IDataResult<List<BodyReadDto>> GetAll()
        {
            var body = _bodydal.GetAll();    
            var bodydto = _mapper.Map<List<BodyReadDto>>(body);

            if (bodydto == null || bodydto.Count == 0)
            {
                return new ErrorDataResult<List<BodyReadDto>>(bodydto, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<List<BodyReadDto>>(bodydto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

        public IDataResult<BodyReadDto> GetById(int id)
        {
            var body = _bodydal.GetById(id);
            var bodydto = _mapper.Map<BodyReadDto>(body);

            if (bodydto == null)
            {
                return new ErrorDataResult<BodyReadDto>(bodydto, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<BodyReadDto>(bodydto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

    }
}
