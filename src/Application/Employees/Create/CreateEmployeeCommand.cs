using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Dependencies.Services;
using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Domain.Entities.Users.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicketRemaster.Application.Employees.Create;
public record CreateEmployeeCommand : IRequest<Employee>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Language { get; set; }
    public string ProfilPicture { get; set; }
    public TGroup group { get; set; }
}

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IIdentityService _identityService;

    public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IIdentityService identityService)
        => (_unitOfWork, _identityService) = (unitOfWork, identityService);

    public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {

        (var appUserCreated, var appUserId) = await _identityService.CreateUserAsync(request.Email, "Password123!", "Employee");
        
        if(!appUserCreated)
            throw new Exception("Error creating user");

        var employee = new Employee();
        employee.UpdateFirstName(request.FirstName);
        employee.UpdateLastName(request.LastName);
        employee.UpdateEmail(request.Email);
        employee.UpdatePhoneNumber(request.PhoneNumber);
        employee.UpdateLanguage(request.Language);
        employee.UpdateProfilPicture(request.ProfilPicture);
        employee.UpdateGroup(request.group);
        employee.UpdateApplicationUserId(appUserId);


        _unitOfWork.Employees.Add(employee);
        await _unitOfWork.SaveChanges();

        return employee;
    }
}