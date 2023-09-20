using MyTicketRemaster.Application.Common.Dependencies.DataAccess;

namespace MyTicketRemaster.Application.Employees.GetDetails;

public record GetEmployeeDetailsQuery : IRequest<EmployeeDetailsDto>
{
    public int Id { get; init; }
}

public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery, EmployeeDetailsDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEmployeeDetailsQueryHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public Task<EmployeeDetailsDto> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}