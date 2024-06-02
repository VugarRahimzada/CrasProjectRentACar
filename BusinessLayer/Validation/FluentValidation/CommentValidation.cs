using BusinessLayer.BaseMessage;
using EntityLayer.Concrete.DTOs.CommentDTOs;
using EntityLayer.Concrete.TableModels;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidation
{
    public class CommentValidation : AbstractValidator<Comment>
    {
        public CommentValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(Messages.GetRequiredMessage("Name"))
                .MinimumLength(3)
                .WithMessage(Messages.GetMinLengthMessage(3, "Name"))
                .MaximumLength(100)
                .WithMessage(Messages.GetMaxLengthMessage(100, "Name"));

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(Messages.GetRequiredMessage("Email"))
                .EmailAddress()
                .WithMessage(Messages.EMAIL_NOT_VALID);

            RuleFor(x => x.Content)
                .NotEmpty()
                  .WithMessage(Messages.GetRequiredMessage("Content"))
                .MinimumLength(3)
                 .WithMessage(Messages.GetMinLengthMessage(3, "Content"))
                .MaximumLength(500)
                .WithMessage(Messages.GetMaxLengthMessage(500, "Content"));

            RuleFor(x => x.BlogId)
                .NotEmpty()
                .WithMessage(Messages.GetRequiredMessage("BlogId"))
                .GreaterThan(0)
                .WithMessage(Messages.PostivIntegerMessage("BlogId"));
        }
    }
}
