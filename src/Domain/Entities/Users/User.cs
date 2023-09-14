using MyTicketRemaster.Domain.Common;
using System.Diagnostics.CodeAnalysis;
using System.Transactions;

namespace MyTicketRemaster.Domain.Entities.Users
{
    public abstract class User : MyEntity
    {
        [Required]
        [StringLength(UserInvariants.NameMaxLength)]
        public string Name { get; private set; }

        [Required]
        public string ApplicationUserId { get; private set; }

        protected User()// EF
        {
            Name = default!;
            ApplicationUserId = default!;
        }

        public User(string name)
        {
            UpdateName(name);
        }


        [MemberNotNull(nameof(Name))]
        public virtual void UpdateName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty.");

            if (value.Length > UserInvariants.NameMaxLength)
                throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum name length ({UserInvariants.NameMaxLength}).");

            Name = value;
        }
    }
}
