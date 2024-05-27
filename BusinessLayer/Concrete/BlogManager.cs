using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.BaseMessage;
using CoreLayer.Extension;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete.ErrorResult;
using CoreLayer.Results.Concrete.SuccessResult;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete.DTOs.BlogDTOs;
using EntityLayer.Concrete.TableModels;
using System.Net;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogdal;
        private readonly IMapper _mapper;

        public BlogManager(IBlogDal blogdal, IMapper mapper)
        {
            _blogdal = blogdal;
            _mapper = mapper;
        }

        public IResult Add(BlogCreateDto entity, string webRootPath)
        {
            var value = _mapper.Map<Blog>(entity);
            value.PhotoPath = PictureHelper.UploadImage(entity.PhotoPath, webRootPath);
            _blogdal.Add(value);
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
            var value = _mapper.Map<Blog>(entity);
            if (entity == null)
            {
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);

            }
            _blogdal.Update(value);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_UPDATE);
        }

        public IDataResult<List<BlogReadDto>> GetAll()
        {
            var value = _blogdal.GetAll();
            var valuedto = _mapper.Map<List<BlogReadDto>>(value);
            if (value == null)
            {
                return new ErrorDataResult<List<BlogReadDto>>(valuedto, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<List<BlogReadDto>>(valuedto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

        public IDataResult<List<BlogReadActivDto>> GetAllActive()
        {
            var value = _blogdal.GetActiveAll();
            var valuedto = _mapper.Map<List<BlogReadActivDto>>(value);
            if (valuedto == null)
            {
                return new ErrorDataResult<List<BlogReadActivDto>>(valuedto, HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
            return new SuccessDataResult<List<BlogReadActivDto>>(valuedto, HttpStatusCode.OK, "Data retrieved successfully");
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
