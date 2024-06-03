using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete.ErrorResult;
using CoreLayer.Results.Concrete.SuccessResult;
using CoreLayer.Validation;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete.DTOs.AboutDTOs;
using EntityLayer.Concrete.TableModels;
using FluentValidation;
using System.Net;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        private readonly IMapper _mapper;
        private readonly IValidator<About> _validator;
        public AboutManager(IAboutDal aboutDal, IMapper mapper, IValidator<About> validator)
        {
            _aboutDal = aboutDal;
            _mapper = mapper;
            _validator = validator;
        }

        public IResult Add(AboutCreateDto entity)
        {
            var about = _mapper.Map<About>(entity);
            var validationResult = ValidationTool.Validate(about, _validator);
            if (validationResult != null)
            {
                return validationResult;
            }

            _aboutDal.Add(about);
            return new SuccessResult(HttpStatusCode.Created, Messages.SUCCESFULLY_ADDED);
        }

        public IResult Delete(int id)
        {
            var value = _aboutDal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _aboutDal.Delete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }
        public IResult HardDelete(int id)
        {
            var value = _aboutDal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _aboutDal.HardDelete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }

        public IResult Update(AboutUpdateDto entity)
        {
            var value = _aboutDal.GetById(entity.Id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            value = _mapper.Map(entity, value);

            var validationResult = ValidationTool.Validate(value, _validator);
            if (validationResult != null)
            {
                return validationResult;
            }

            _aboutDal.Update(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_UPDATE);
        }


        public IDataResult<List<AboutReadDto>> GetAll()
        {
            var about = _aboutDal.GetAll();
            var aboutdto = _mapper.Map<List<AboutReadDto>>(about);

            if (aboutdto == null || aboutdto.Count == 0)
            {
                return new ErrorDataResult<List<AboutReadDto>>(aboutdto, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<List<AboutReadDto>>(aboutdto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

        public IDataResult<AboutReadDto> GetById(int id)
        {
            var about = _aboutDal.GetById(id);
            var aboutdto = _mapper.Map<AboutReadDto>(about);

            if (aboutdto == null)
            {
                return new ErrorDataResult<AboutReadDto>(aboutdto, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<AboutReadDto>(aboutdto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

    }
}
