using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Users.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicketRemaster.Application.Customers.GetList;

public record CustomerDto : IMapFrom<Customer>
{

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Customer, CustomerDto>();
    }
}

