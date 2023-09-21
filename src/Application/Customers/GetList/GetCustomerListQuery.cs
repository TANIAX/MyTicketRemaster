using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicketRemaster.Application.Customers.GetList;

public record GetCustomerListQuery : IRequest<List<CustomerDto>>
{

}

public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<CustomerDto>>
{
    public Task<List<CustomerDto>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}