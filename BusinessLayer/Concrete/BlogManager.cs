using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.BaseMessage;
using CoreLayer.Extension;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete.ErrorResult;
using CoreLayer.Results.Concrete.SuccessResult;
using CoreLayer.Validation;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete.DTOs.BlogDTOs;
using EntityLayer.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using IResult = CoreLayer.Results.Abstract.IResult;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogdal;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IValidator<Blog> _blogValidator;

        public BlogManager(IBlogDal blogdal, IMapper mapper, IWebHostEnvironment webHostEnvironment, IValidator<Blog> blogValidator)
        {
            _blogdal = blogdal;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _blogValidator = blogValidator;
        }

        public IResult Add(BlogCreateDto entity)
        {

            var blog = _mapper.Map<Blog>(entity);
            var validationResult = ValidationTool.Validate<Blog>(blog, _blogValidator);
            if (validationResult != null)
            {
                return validationResult;
            }

            blog.PhotoPath = PictureHelper.UploadImage(entity.PhotoPath, _webHostEnvironment.WebRootPath);
            _blogdal.Add(blog);
            return new SuccessResult(HttpStatusCode.Created, Messages.SUCCESFULLY_ADDED);
        }

        public IResult Delete(int id)
        {
            var value = _blogdal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _blogdal.Delete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }

        public IResult HardDelete(int id)
        {
            var value = _blogdal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            _blogdal.HardDelete(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.PERMANENTLY_SUCCESFULLY_DELETED);
        }

        public IResult Update(BlogUpdateDto entity)
        {
            var existingBlog = _blogdal.GetById(entity.Id);

            if (existingBlog == null)
            {
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }

            var blog = _mapper.Map<Blog>(entity);

            if (entity.PhotoPath != null)
            {
                blog.PhotoPath = PictureHelper.UploadImage(entity.PhotoPath, _webHostEnvironment.WebRootPath);
            }
            else
            {
                blog.PhotoPath = existingBlog.PhotoPath;
            }


            var validationResult = ValidationTool.Validate(blog, _blogValidator);

            if (validationResult != null)
            {
                return validationResult;
            }


            _blogdal.Update(blog);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_UPDATE);
        }

        public IDataResult<List<BlogReadDto>> GetAll()
        {
            var value = _blogdal.GetAll();
            var valuedto = _mapper.Map<List<BlogReadDto>>(value);
            if (valuedto == null || valuedto.Count == 0)
            {
                return new ErrorDataResult<List<BlogReadDto>>(valuedto, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<List<BlogReadDto>>(valuedto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

        public IDataResult<List<BlogReadActivDto>> GetAllActive()
        {
            var value = _blogdal.GetAllWithComments();
            var valuedto = _mapper.Map<List<BlogReadActivDto>>(value);
            if (valuedto == null || valuedto.Count == 0)
            {
                return new ErrorDataResult<List<BlogReadActivDto>>(valuedto, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<List<BlogReadActivDto>>(valuedto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

        public IDataResult<BlogReadDto> GetById(int id)
        {
            var value = _blogdal.GetById(id);
            var valuedto = _mapper.Map<BlogReadDto>(value);
            if (valuedto == null)
            {
                return new ErrorDataResult<BlogReadDto>(valuedto, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }


            return new SuccessDataResult<BlogReadDto>(valuedto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

        public void CommentCouta(int id)
        {
            var value = _blogdal.GetById(id);

            value.CommentCounta++;
        }
    }
}
