
using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Domain.Entities.Users.Contacts;

namespace MyTicketRemaster.Application.Contacts.Create;

public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContactCommandValidator()
    {
        RuleFor(v => v.FirstName)
            .NotEmpty().WithMessage("FirstName is required")
            .MaximumLength(ContactInvariants.FirstNameMaxLength).WithMessage($"FirstName must not exceed {ContactInvariants.FirstNameMaxLength} characters");

        RuleFor(v => v.LastName)
            .NotEmpty().WithMessage("LastName is required")
            .MaximumLength(ContactInvariants.LastNameMaxLength).WithMessage($"LastName must not exceed {ContactInvariants.LastNameMaxLength} characters");

        RuleFor(v => v.Email)
           .NotEmpty().WithMessage("Email is required")
           .MaximumLength(ContactInvariants.EmailMaxLength).WithMessage($"Email must not exceed {ContactInvariants.EmailMaxLength} characters")
           .EmailAddress();

        RuleFor(v => v.PhoneNumber)
           .MaximumLength(ContactInvariants.PhoneNumberMaxLength).WithMessage($"Phone number must not exceed {ContactInvariants.PhoneNumberMaxLength} characters");

        RuleFor(v => v.Language)
           .MaximumLength(ContactInvariants.LanguageMaxLength).WithMessage($"Language must not exceed {ContactInvariants.LanguageMaxLength} characters");
    }
}

