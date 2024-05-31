using BusinessLayer.BaseMessage;
using EntityLayer.Concrete.TableModels;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidation
{
    public class BrandValidation : AbstractValidator<Brand>
    {
        public BrandValidation()
        {
            RuleFor(x => x.BrandName)
                 .NotEmpty()
                 .WithMessage(Messages.GetRequiredMessage("BrandName"))
                 .MinimumLength(3)
                 .WithMessage(Messages.GetMinLengthMessage(3, "BrandName"))
                 .MaximumLength(200)
                 .WithMessage(Messages.GetMaxLengthMessage(200, "BrandName"));
        }
    }
}
