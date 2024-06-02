using BusinessLayer.BaseMessage;
using EntityLayer.Concrete.TableModels;
using FluentValidation;

namespace BusinessLayer.Validation.FluentValidation
{
    public class BookingValidation : AbstractValidator<Booking>
    {
        public BookingValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(Messages.GetRequiredMessage("Name"))
                .MinimumLength(3).WithMessage(Messages.GetMinLengthMessage(3, "Name"))
                .MaximumLength(100).WithMessage(Messages.GetMaxLengthMessage(100, "Name"));

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(Messages.GetRequiredMessage("Email"))
                .EmailAddress().WithMessage(Messages.EMAIL_NOT_VALID);

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage(Messages.GetRequiredMessage("Phone"))
                .MinimumLength(3).WithMessage(Messages.GetMinLengthMessage(3, "Phone"))
                .MaximumLength(50).WithMessage(Messages.GetMaxLengthMessage(50, "Phone"));

            RuleFor(x => x.Request)
                .NotEmpty().WithMessage(Messages.GetRequiredMessage("Request"))
                .MinimumLength(3).WithMessage(Messages.GetMinLengthMessage(3, "Request"))
                .MaximumLength(500).WithMessage(Messages.GetMaxLengthMessage(500, "Request"));

            RuleFor(x => x.Destination)
                .NotEmpty().WithMessage(Messages.GetRequiredMessage("Destination"))
                .MinimumLength(3).WithMessage(Messages.GetMinLengthMessage(3, "Destination"))
                .MaximumLength(500).WithMessage(Messages.GetMaxLengthMessage(500, "Destination"));

            RuleFor(x => x.PickUpLocation)
                .NotEmpty().WithMessage(Messages.GetRequiredMessage("PickUpLocation"))
                .MinimumLength(3).WithMessage(Messages.GetMinLengthMessage(3, "PickUpLocation"))
                .MaximumLength(500).WithMessage(Messages.GetMaxLengthMessage(500, "PickUpLocation"));

            RuleFor(x => x.PickUpDate)
                .NotEmpty().WithMessage(Messages.GetRequiredMessage("PickUpDate"));

            RuleFor(x => x.ReturnDate)
                .NotEmpty().WithMessage(Messages.GetRequiredMessage("ReturnDate"));
        }
    }
}
