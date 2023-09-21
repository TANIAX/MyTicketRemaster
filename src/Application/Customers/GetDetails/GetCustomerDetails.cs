using MyTicketRemaster.Application.Common.Dependencies.DataAccess;

namespace MyTicketRemaster.Application.Customers.GetDetails;

public record GetCustomerDetailsQuery : IRequest<CustomerDetailsDto>
{
    public int Id { get; set; }
}

public class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, CustomerDetailsDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCustomerDetailsQueryHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public Task<CustomerDetailsDto> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}