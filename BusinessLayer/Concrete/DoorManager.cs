using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete.ErrorResult;
using CoreLayer.Results.Concrete.SuccessResult;
using CoreLayer.Validation;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete.DTOs.DoorDTOs;
using EntityLayer.Concrete.TableModels;
using FluentValidation;
using System.Net;

namespace BusinessLayer.Concrete
{
    public class DoorManager : IDoorService
    {
        private readonly IDoorDal _doorDal;
        private readonly IMapper _mapper;
        private readonly IValidator<Door> _validator;

        public DoorManager(IDoorDal doorDal, IMapper mapper, IValidator<Door> validator)
        {
            _doorDal = doorDal;
            _mapper = mapper;
            _validator = validator;
        }

        public IResult Add(DoorCreateDto entity)
        {
            var door = _mapper.Map<Door>(entity);
            var validationResult = ValidationTool.Validate(door, _validator);
            if (validationResult != null)
            {
                return validationResult;
            }

            _doorDal.Add(door);
            return new SuccessResult(HttpStatusCode.Created, Messages.SUCCESFULLY_ADDED);
        }

        public IResult Delete(int id)
        {
            var value = _doorDal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _doorDal.Delete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }

        public IResult HardDelete(int id)
        {
            var value = _doorDal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _doorDal.HardDelete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }

        public IResult Update(DoorUpdateDto entity)
        {
            var value = _doorDal.GetById(entity.Id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _mapper.Map(entity, value);
            _doorDal.Update(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_UPDATE);
        }

        public IDataResult<List<DoorReadDto>> GetAll()
        {
            var doors = _doorDal.GetAll();
            var doorDtos = _mapper.Map<List<DoorReadDto>>(doors);

            if (doorDtos == null || doorDtos.Count == 0)
            {
                return new ErrorDataResult<List<DoorReadDto>>(doorDtos, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<List<DoorReadDto>>(doorDtos, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

        public IDataResult<DoorReadDto> GetById(int id)
        {
            var door = _doorDal.GetById(id);
            var doorDto = _mapper.Map<DoorReadDto>(door);

            if (doorDto == null)
            {
                return new ErrorDataResult<DoorReadDto>(doorDto, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<DoorReadDto>(doorDto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }
    }
}
