using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.BaseMessage;
using BusinessLayer.Validation.FluentValidation;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete.ErrorResult;
using CoreLayer.Results.Concrete.SuccessResult;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete.DTOs.CommentDTOs;
using EntityLayer.Concrete.TableModels;
using System.Net;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        private readonly IBlogDal _blogDal;
        private readonly IMapper _mapper;

        public CommentManager(ICommentDal commentDal, IMapper mapper, IBlogDal blogDal)
        {
            _commentDal = commentDal;
            _mapper = mapper;
            _blogDal = blogDal;
        }

        public IResult Add(CommentCreateDto entity)
        {
            var value = _mapper.Map<Comment>(entity);

            var blog = _blogDal.GetActiveAll();

            var validation = new CommentValidation();
            var validationResult = validation.Validate(entity);
            List<string>  test = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            if (!validationResult.IsValid)
            {
                return new ErrorDataResult<List<string>>(test,HttpStatusCode.BadRequest);
            }

            if (!blog.Any(x => x.Id == entity.BlogId))
            {
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);
            }
         
            _commentDal.Add(value);
            _blogDal.IncreesCommentCounta(entity.BlogId);

            return new SuccessResult(HttpStatusCode.Created, Messages.SUCCESFULLY_ADDED);
        }

        public IResult Delete(int id)
        {
            var value = _commentDal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.BLOG_NOT_FOUND);
            _commentDal.Delete(value);
            _blogDal.IncreesCommentCounta(id);
            return new SuccessResult(HttpStatusCode.OK, Messages.SUCCESFULLY_DELETED);
        }

        public IResult HardDelete(int id)
        {
            var value = _commentDal.GetById(id);
            if (value == null)
                return new ErrorResult(HttpStatusCode.NotFound, Messages.NOT_FOUND);
            _commentDal.HardDelete(value);
            _blogDal.IncreesCommentCounta(id);
            return new SuccessResult(HttpStatusCode.OK, Messages.PERMANENTLY_SUCCESFULLY_DELETED);
        }
        public IDataResult<List<CommentReadDto>> GetAll()
        {
            var value = _commentDal.GetAll();
            var valuedto = _mapper.Map<List<CommentReadDto>>(value);
            return new SuccessDataResult<List<CommentReadDto>>(valuedto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

        public IDataResult<List<CommentReadActiveDto>> GetAllActive()
        {
            var value = _commentDal.GetActiveAll();
            var valuedto = _mapper.Map<List<CommentReadActiveDto>>(value);
            return new SuccessDataResult<List<CommentReadActiveDto>>(valuedto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

        public IDataResult<CommentReadDto> GetById(int id)
        {
            var value = _commentDal.GetById(id);
            var valuedto = _mapper.Map<CommentReadDto>(value);


            return new SuccessDataResult<CommentReadDto>(valuedto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }
        public IDataResult<List<CommentReadActiveDto>> GetCommentsByBlogId(int id)
        {
            var value = _commentDal.GetCommentsByBlogId(id);
            var valuedto = _mapper.Map<List<CommentReadActiveDto>>(value);


            if (value == null)
                return new ErrorDataResult<List<CommentReadActiveDto>>(valuedto, HttpStatusCode.NotFound, Messages.NOT_FOUND);



            return new SuccessDataResult<List<CommentReadActiveDto>>(valuedto, HttpStatusCode.OK, Messages.DATA_SUCCESFULLY_RETRIEVED);
        }

    }
}
