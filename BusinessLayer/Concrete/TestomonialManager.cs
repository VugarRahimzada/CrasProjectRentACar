using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.BaseMessage;
using CoreLayer.Extension;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete.ErrorResult;
using CoreLayer.Results.Concrete.SuccessResult;
using CoreLayer.Validation;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete.DTOs.TestomonialDTOs;
using EntityLayer.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata;

namespace BusinessLayer.Concrete
{
    public class TestomonialManager : ITestomonialService
    {
        private readonly ITestomonialDal _testomonialDal;
        private readonly IMapper _mapper;
        private readonly IValidator<Testomonial> _validator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TestomonialManager(ITestomonialDal testomonialDal, IMapper mapper, IValidator<Testomonial> validator, IWebHostEnvironment webHostEnvironment)
        {
            _testomonialDal = testomonialDal;
            _mapper = mapper;
            _validator = validator;
            _webHostEnvironment = webHostEnvironment;
        }

        public IResult Add(TestomonialCreateDto entity)
        {
            var testomonial = _mapper.Map<Testomonial>(entity);
            var validationResult = ValidationTool.Validate(testomonial, _validator);
            if (validationResult != null)
            {
                return validationResult;
            }

            testomonial.PhotoPath = PictureHelper.UploadImage(entity.PhotoPath, _webHostEnvironment.WebRootPath);
            _testomonialDal.Add(testomonial);
            return new SuccessResult(HttpStatusCode.Created, Messages.SUCCESFULLY_ADDED);
        }

        public IResult Delete(int id)
        {
            var value = _testomonialDal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _testomonialDal.Delete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }
        public IResult HardDelete(int id)
        {
            var value = _testomonialDal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _testomonialDal.HardDelete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }

        public IResult Update(TestomonialUpdateDto entity)
        {
            var value = _testomonialDal.GetById(entity.Id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

           var testomonial = _mapper.Map(entity, value);

            if (entity.PhotoPath != null)
            {
                value.PhotoPath = PictureHelper.UploadImage(entity.PhotoPath, _webHostEnvironment.WebRootPath);
            }
            else
            {
                value.PhotoPath = testomonial.PhotoPath;
            }


            var validationResult = ValidationTool.Validate(testomonial, _validator);
            if (validationResult != null)
            {
                return validationResult;
            }

            _testomonialDal.Update(testomonial);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_UPDATE);
        }

        public IDataResult<List<TestomonialReadDto>> GetAll()
        {
            var testomonials = _testomonialDal.GetAll();
            var testomonialDtos = _mapper.Map<List<TestomonialReadDto>>(testomonials);

            if (testomonialDtos == null || testomonialDtos.Count == 0)
            {
                return new ErrorDataResult<List<TestomonialReadDto>>(testomonialDtos, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<List<TestomonialReadDto>>(testomonialDtos, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }
        public IDataResult<List<TestomonialReadActiveDto>> GetAllActive()
        {
            var testomonials = _testomonialDal.GetAll(x => x.Delete == 0);
            var testomonialDtos = _mapper.Map<List<TestomonialReadActiveDto>>(testomonials);

            if (testomonialDtos == null || testomonialDtos.Count == 0)
            {
                return new ErrorDataResult<List<TestomonialReadActiveDto>>(testomonialDtos, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<List<TestomonialReadActiveDto>>(testomonialDtos, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

        public IDataResult<TestomonialReadDto> GetById(int id)
        {
            var testomonial = _testomonialDal.GetById(id);
            var testomonialDto = _mapper.Map<TestomonialReadDto>(testomonial);

            if (testomonialDto == null)
            {
                return new ErrorDataResult<TestomonialReadDto>(testomonialDto, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<TestomonialReadDto>(testomonialDto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }
    }
}
