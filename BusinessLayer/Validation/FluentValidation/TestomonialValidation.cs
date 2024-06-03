using BusinessLayer.BaseMessage;
using EntityLayer.Concrete.TableModels;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidation
{
    public class TestomonialValidation : AbstractValidator<Testomonial>
    {
        public TestomonialValidation()
        {
            RuleFor(x => x.Name)
                 .NotEmpty()
                 .WithMessage(Messages.GetRequiredMessage("Name"))
                 .MinimumLength(3)
                 .WithMessage(Messages.GetMinLengthMessage(3, "Name"))
                 .MaximumLength(100)
                 .WithMessage(Messages.GetMaxLengthMessage(100, "Name"));

            RuleFor(x => x.Surname)
                 .NotEmpty()
                 .WithMessage(Messages.GetRequiredMessage("Surname"))
                 .MinimumLength(3)
                 .WithMessage(Messages.GetMinLengthMessage(3, "Surname"))
                 .MaximumLength(250)
                 .WithMessage(Messages.GetMaxLengthMessage(250, "Surname"));

            RuleFor(x => x.Position)
                 .NotEmpty()
                 .WithMessage(Messages.GetRequiredMessage("Position"))
                 .MinimumLength(3)
                 .WithMessage(Messages.GetMinLengthMessage(3, "Position"))
                 .MaximumLength(250)
                 .WithMessage(Messages.GetMaxLengthMessage(250, "Position"));

            RuleFor(x => x.LinkedIn)
                 .NotEmpty()
                 .WithMessage(Messages.GetRequiredMessage("LinkedIn"))
                 .MinimumLength(3)
                 .WithMessage(Messages.GetMinLengthMessage(3, "LinkedIn"))
                 .MaximumLength(500)
                 .WithMessage(Messages.GetMaxLengthMessage(500, "LinkedIn"));


            RuleFor(x => x.PhotoPath)
                 .NotEmpty()
                 .WithMessage(Messages.GetRequiredMessage("PhotoPath"))
                 .MinimumLength(3)
                 .WithMessage(Messages.GetMinLengthMessage(3, "PhotoPath"))
                 .MaximumLength(500)
                 .WithMessage(Messages.GetMaxLengthMessage(500, "PhotoPath"));
        }
    }
}
