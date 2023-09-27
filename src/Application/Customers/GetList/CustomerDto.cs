using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Users;
using MyTicketRemaster.Domain.Entities.Users.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicketRemaster.Application.Customers.GetList;

public record CustomerDto : IMapFrom<Customer>
{
    public int Id { get; set; }
    public string CompanyName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Signature { get; private set; }
    public string Language { get; private set; }
    public string? ProfilPicture { get; private set; }
    public Address Address { get; private set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Customer, CustomerDto>();
    }
}

