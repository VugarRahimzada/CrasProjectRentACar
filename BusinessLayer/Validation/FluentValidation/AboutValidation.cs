using BusinessLayer.BaseMessage;
using EntityLayer.Concrete.TableModels;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidation
{
    public class AboutValidation : AbstractValidator<About>
    {
        public AboutValidation()
        {
            RuleFor(x => x.Title)
                 .NotEmpty()
                 .WithMessage(Messages.GetRequiredMessage("Title"))
                 .MinimumLength(3)
                 .WithMessage(Messages.GetMinLengthMessage(3, "Title"))
                 .MaximumLength(250)
                 .WithMessage(Messages.GetMaxLengthMessage(250, "Title"));

            RuleFor(x => x.Text)
                 .NotEmpty()
                 .WithMessage(Messages.GetRequiredMessage("Text"))
                 .MinimumLength(3)
                 .WithMessage(Messages.GetMinLengthMessage(3, "Text"))
                 .MaximumLength(2000)
                 .WithMessage(Messages.GetMaxLengthMessage(2000, "Text"));
        }
    }
}
