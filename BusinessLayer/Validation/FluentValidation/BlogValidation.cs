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
                 .MaximumLength(100)
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
    public class CarValidation : AbstractValidator<Car>
    {
        public CarValidation()
        {
            RuleFor(x => x.Name)
                 .NotEmpty()
                 .WithMessage(Messages.GetRequiredMessage("Name"))
                 .MinimumLength(3)
                 .WithMessage(Messages.GetMinLengthMessage(3, "Name"))
                 .MaximumLength(100)
                 .WithMessage(Messages.GetMaxLengthMessage(100, "Name"));

            RuleFor(x => x.Seat)
                .GreaterThan((byte)0)
                .WithMessage(Messages.GetRequiredMessage("Seat"));

            RuleFor(x => x.Luggage)
                .GreaterThanOrEqualTo((short)0)
                .WithMessage(Messages.GetRequiredMessage("Luggage"));

            RuleFor(x => x.Engine)
                .GreaterThan((short)0)
                .WithMessage(Messages.GetRequiredMessage("Engine"));

            RuleFor(x => x.Year)
                .NotEmpty()
                .WithMessage(Messages.GetRequiredMessage("Year"));

            RuleFor(x => x.FuelEconomy)
                .GreaterThanOrEqualTo(0)
                .WithMessage(Messages.GetRequiredMessage("FuelEconomy"));

            RuleFor(x => x.Kilometer)
                .GreaterThanOrEqualTo(0)
                .WithMessage(Messages.GetRequiredMessage("Kilometer"));

            RuleFor(x => x.ExteriorColor)
                .NotEmpty()
                .WithMessage(Messages.GetRequiredMessage("ExteriorColor"))
                 .MinimumLength(3)
                .WithMessage(Messages.GetMaxLengthMessage(3, "ExteriorColor"))
                .MaximumLength(100)
                .WithMessage(Messages.GetMaxLengthMessage(100, "ExteriorColor"));

            RuleFor(x => x.InteriorColor)
                .NotEmpty()
                .WithMessage(Messages.GetRequiredMessage("InteriorColor"))
                .MinimumLength(3)
                .WithMessage(Messages.GetMaxLengthMessage(3, "InteriorColor"))
                .MaximumLength(100)
                .WithMessage(Messages.GetMaxLengthMessage(100, "InteriorColor"));

            RuleFor(x=>x.PhotoPath)
                .NotEmpty()
                .WithMessage(Messages.GetRequiredMessage("PhotoPath"))
                .MinimumLength(3)
                .WithMessage(Messages.GetMaxLengthMessage(3, "PhotoPath"))
                .MaximumLength(100)
                .WithMessage(Messages.GetMaxLengthMessage(100, "PhotoPath"));

        }
    }
}
