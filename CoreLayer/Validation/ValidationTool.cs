using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete.ErrorResult;
using FluentValidation;
using System.Net;

namespace CoreLayer.Validation
{
    public class ValidationTool
    {
        public static IResult Validate<TEntity>(TEntity entity, IValidator<TEntity> validator)
        {
            var validationResult = validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                var validationMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return new ErrorDataResult<List<string>>(validationMessages, HttpStatusCode.BadRequest);
            }
            return null;
        }
}
}
