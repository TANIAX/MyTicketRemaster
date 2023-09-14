using MyTicketRemaster.Domain.Common;
using System.Diagnostics.CodeAnalysis;

namespace MyTicketRemaster.Domain.Entities.Users.Customers
{
    public class Customer : User
    {
        [Required]
        public Address Address { get; private set; }

        private Customer()// EF
        {
            Address = default!;
        }

        public Customer(string name, Address address)
        {
            //UpdateName(name);
            UpdateAddress(address);
        }



        [MemberNotNull(nameof(Address))]
        public void UpdateAddress(Address address)
        {
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

    }
}
