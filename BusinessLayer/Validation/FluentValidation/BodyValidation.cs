using BusinessLayer.BaseMessage;
using EntityLayer.Concrete.TableModels;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidation
{
    public class BodyValidation : AbstractValidator<Body>
    {
        public BodyValidation()
        {
            RuleFor(x => x.Type)
                 .NotEmpty()
                 .WithMessage(Messages.GetRequiredMessage("Type"))
                 .MinimumLength(3)
                 .WithMessage(Messages.GetMinLengthMessage(3, "Type"))
                 .MaximumLength(200)
                 .WithMessage(Messages.GetMaxLengthMessage(200, "Type"));
        }
    }
}
