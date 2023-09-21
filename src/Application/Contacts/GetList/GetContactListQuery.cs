using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicketRemaster.Application.Contacts.GetList;

public record GetContactListQuery : IRequest<List<ContactDto>>
{

}

public class GetContactListQueryHandler : IRequestHandler<GetContactListQuery, List<ContactDto>>
{
    public Task<List<ContactDto>> Handle(GetContactListQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}