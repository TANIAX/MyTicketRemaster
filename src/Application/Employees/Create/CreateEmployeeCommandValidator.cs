
using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Domain.Entities.Users;
using MyTicketRemaster.Domain.Entities.Users.Employee;

namespace MyTicketRemaster.Application.Employees.Create;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateEmployeeCommandValidator(IUnitOfWork unitOfWork)
    {

        _unitOfWork = unitOfWork;

        RuleFor(v => v.FirstName)
            .NotEmpty().WithMessage("FirstName is required")
            .MaximumLength(EmployeeInvariants.FirstNameMaxLength).WithMessage($"FirstName must not exceed {EmployeeInvariants.FirstNameMaxLength} characters");

        RuleFor(v => v.LastName)
            .NotEmpty().WithMessage("LastName is required")
            .MaximumLength(EmployeeInvariants.LastNameMaxLength).WithMessage($"LastName must not exceed {EmployeeInvariants.LastNameMaxLength} characters");

        RuleFor(v => v.Email)
           .NotEmpty().WithMessage("Email is required")
           .MaximumLength(UserInvariants.EmailMaxLength).WithMessage($"Email must not exceed {UserInvariants.EmailMaxLength} characters")
           .EmailAddress()
           .MustAsync(BeUniqueEmail).WithMessage("The specified email already exists.");

        RuleFor(v => v.PhoneNumber)
           .MaximumLength(UserInvariants.PhoneNumberMaxLength).WithMessage($"Phone number must not exceed {UserInvariants.PhoneNumberMaxLength} characters");

        RuleFor(v => v.Language)
           .MaximumLength(UserInvariants.LanguageMaxLength).WithMessage($"Language must not exceed {UserInvariants.LanguageMaxLength} characters");
        
        RuleFor(v => v.group)
            .NotNull().WithMessage("Group is required")
            .MustAsync(GroupExist).WithMessage("The specified group does not exist.");
    }

    private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
    {
        var employeeExist =  await _unitOfWork.Employees.GetByEmailAsync(email);
        var customerExist = await _unitOfWork.Customers.GetByEmailAsync(email);
        var contactExist = await _unitOfWork.Contacts.GetByEmailAsync(email);

        return employeeExist == null && customerExist == null && contactExist == null;
    }

    private async Task<bool> GroupExist(TGroup group, CancellationToken cancellationToken)
    {
        var groupExist = await _unitOfWork.Groups.GetByIdAsync(group.Id);

        return groupExist != null;
    }
}

