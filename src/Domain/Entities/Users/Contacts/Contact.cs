using MyTicketRemaster.Domain.Common;
using MyTicketRemaster.Domain.Entities.Users.Contact;
using System.Diagnostics.CodeAnalysis;

namespace MyTicketRemaster.Domain.Entities.Users.Contacts
{
    public class TContact : User
    {
        //[Required]
        //public Address Address { get; private set; }

        //private TContact()// EF
        //{
        //    Address = default!;
        //}

        //public TContact(string name, Address address)
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
}
