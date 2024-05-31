using BusinessLayer.BaseMessage;
using EntityLayer.Concrete.TableModels;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidation
{
    public class BlogValidation : AbstractValidator<Blog>
    {
        public BlogValidation()
        {
            RuleFor(x => x.Title)
                 .NotEmpty()
                 .WithMessage(Messages.GetRequiredMessage("Title"))
                 .MinimumLength(3)
                 .WithMessage(Messages.GetMinLengthMessage(3, "Title"))
                 .MaximumLength(200)
                 .WithMessage(Messages.GetMaxLengthMessage(200, "Title"));

            RuleFor(x => x.Content)
                .NotEmpty()
                  .WithMessage(Messages.GetRequiredMessage("Content"))
                .MinimumLength(3)
                 .WithMessage(Messages.GetMinLengthMessage(3, "Content"))
                .MaximumLength(500)
                .WithMessage(Messages.GetMaxLengthMessage(500, "Content"));

            RuleFor(x => x.PhotoPath)
                .NotEmpty()
                .WithMessage(Messages.GetRequiredMessage("PhotoPath"))
                .MinimumLength(3)
                .WithMessage(Messages.GetMinLengthMessage(3, "PhotoPath"))
                .MaximumLength(400)
                .WithMessage(Messages.GetMaxLengthMessage(400, "PhotoPath"));
        }
    }
}
