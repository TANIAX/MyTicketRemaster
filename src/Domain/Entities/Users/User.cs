using MyTicketRemaster.Domain.Common;
using System.Diagnostics.CodeAnalysis;
using System.Transactions;

namespace MyTicketRemaster.Domain.Entities.Users
{
    public abstract class User : MyEntity
    {
        [Required]
        public string ApplicationUserId { get; private set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Signature { get; set; }
        public string Language { get; set; }
        public string ProfilPicture { get; set; }

        protected User()
        {
            ApplicationUserId = default!;
        }
    }
}
