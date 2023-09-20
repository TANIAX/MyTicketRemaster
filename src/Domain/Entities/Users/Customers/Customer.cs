using MyTicketRemaster.Domain.Entities.Users.Contacts;
using System.Diagnostics.CodeAnalysis;

namespace MyTicketRemaster.Domain.Entities.Users.Customers;

public class Customer : User
{
    //public string CompanyName { get; set; }
    //public virtual ICollection<TContact> Contacts { get; private set; }


    //[Required]
    //public Address Address { get; private set; }

    //private Customer()// EF
    //{
    //    Address = default!;
    //}

    //public Customer(string name, Address address)
    //{
    //    //UpdateName(name);
    //    UpdateAddress(address);
    //}



    //[MemberNotNull(nameof(Address))]
    //public void UpdateAddress(Address address)
    //{
    //    Address = address ?? throw new ArgumentNullException(nameof(address));
    //}
}

