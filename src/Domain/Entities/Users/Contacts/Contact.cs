using MyTicketRemaster.Domain.Common;
using MyTicketRemaster.Domain.Entities.Users.Contact;
using MyTicketRemaster.Domain.Entities.Users.Employee;
using System.Diagnostics.CodeAnalysis;

namespace MyTicketRemaster.Domain.Entities.Users.Contacts
{
    public class TContact : MyEntity
    {
        #region Properties
        [Required]
        [MaxLength(ContactInvariants.FirstNameMaxLength)]
        public string FirstName { get; private set; }

        [Required]
        [MaxLength(ContactInvariants.LastNameMaxLength)]
        public string LastName { get; private set; }

        [MaxLength(ContactInvariants.EmailMaxLength)]
        public string Email { get; private set; } 

        [MaxLength(ContactInvariants.PhoneNumberMaxLength)]
        public string PhoneNumber { get; private set; }

        [MaxLength(ContactInvariants.LanguageMaxLength)]
        public string Language { get; private set; }
        public string ProfilPicture { get; private set; }

        [Required]
        public Address Address { get; private set; }
        #endregion

        #region Constructors
        public TContact() { }
        public TContact(string firstName, string lastName, string email, string phoneNumber, string Language, string profilPicture, Address address)
        {
            UpdateFirstName(firstName);
            UpdateLastName(lastName);
            UpdateEmail(email);
            UpdatePhoneNumber(phoneNumber);
            UpdateLanguage(Language);
            UpdateProfilPicture(profilPicture);
            UpdateAddress(address);
        }
        #endregion

        #region Methods
        public void UpdateFirstName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("FirstName cannot be empty.");

            if (value.Length > EmployeeInvariants.FirstNameMaxLength)
                throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum firstname length ({EmployeeInvariants.FirstNameMaxLength}).");

            FirstName = value;
        }

        public void UpdateLastName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("LastName cannot be empty.");

            if (value.Length > EmployeeInvariants.LastNameMaxLength)
                throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum lastname length ({EmployeeInvariants.FirstNameMaxLength}).");

            FirstName = value;
        }

        public void UpdateEmail(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be empty.");

            if (value.Length > ContactInvariants.EmailMaxLength)
                throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum email length ({ContactInvariants.EmailMaxLength}).");

            Email = value;
        }

        public void UpdatePhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("PhoneNumber cannot be empty.");

            if (value.Length > ContactInvariants.PhoneNumberMaxLength)
                throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum phone number length ({ContactInvariants.PhoneNumberMaxLength}).");

            PhoneNumber = value;
        }

        public void UpdateLanguage(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Language cannot be empty.");

            if (value.Length > ContactInvariants.LanguageMaxLength)
                throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum language length ({ContactInvariants.LanguageMaxLength}).");

            Language = value;
        }

        public void UpdateProfilPicture(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("ProfilPicture cannot be empty.");

            ProfilPicture = value;
        }


        [MemberNotNull(nameof(Address))]
        public void UpdateAddress(Address address)
        {
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }
        #endregion
    }
}
