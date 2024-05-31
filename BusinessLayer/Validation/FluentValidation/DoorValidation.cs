using BusinessLayer.BaseMessage;
using EntityLayer.Concrete.TableModels;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidation
{
    public class DoorValidation : AbstractValidator<Door>
    {
        public DoorValidation()
        {
            RuleFor(x => x.DoorCount)
                 .NotEmpty()
                 .WithMessage(Messages.GetRequiredMessage("Type"))
                 .GreaterThanOrEqualTo(0)
                 .WithMessage(Messages.PostivIntegerMessage("Luggage"));
        }
    }
}
