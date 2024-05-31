using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete.ErrorResult;
using CoreLayer.Results.Concrete.SuccessResult;
using CoreLayer.Validation;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete.DTOs.BrandDTOs;
using EntityLayer.Concrete.TableModels;
using FluentValidation;
using System.Net;

namespace BusinessLayer.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly IMapper _mapper;
        private readonly IValidator<Brand> _validator;

        public BrandManager(IBrandDal brandDal, IMapper mapper, IValidator<Brand> validator)
        {
            _brandDal = brandDal;
            _mapper = mapper;
            _validator = validator;
        }

        public IResult Add(BrandCreateDto entity)
        {
            var brand = _mapper.Map<Brand>(entity);
            var validationResult = ValidationTool.Validate(brand, _validator);
            if (validationResult != null)
            {
                return validationResult;
            }

            _brandDal.Add(brand);
            return new SuccessResult(HttpStatusCode.Created, Messages.SUCCESFULLY_ADDED);
        }

        public IResult Delete(int id)
        {
            var value = _brandDal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _brandDal.Delete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }

        public IResult HardDelete(int id)
        {
            var value = _brandDal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _brandDal.HardDelete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }

        public IResult Update(BrandUpdateDto entity)
        {
            var value = _brandDal.GetById(entity.Id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _brandDal.Update(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_UPDATE);
        }

        public IDataResult<List<BrandReadDto>> GetAll()
        {
            var brands = _brandDal.GetAll();
            var brandDtos = _mapper.Map<List<BrandReadDto>>(brands);

            if (brandDtos == null || brandDtos.Count == 0)
            {
                return new ErrorDataResult<List<BrandReadDto>>(brandDtos, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<List<BrandReadDto>>(brandDtos, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

        public IDataResult<BrandReadDto> GetById(int id)
        {
            var brand = _brandDal.GetById(id);
            var brandDto = _mapper.Map<BrandReadDto>(brand);

            if (brandDto == null)
            {
                return new ErrorDataResult<BrandReadDto>(brandDto, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<BrandReadDto>(brandDto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }
    }
}
