using MyTicketRemaster.Domain.Common;
using System.Diagnostics.CodeAnalysis;
using System.Transactions;

namespace MyTicketRemaster.Domain.Entities.Users
{
    public abstract class User : MyEntity
    {
        #region Properties
        [Required]
        public string ApplicationUserId { get; private set; }

        [Required]
        [MaxLength(UserInvariants.EmailMaxLength)]
        public string Email { get; private set; } 

        [Required]
        [MaxLength(UserInvariants.PhoneNumberMaxLength)]
        public string PhoneNumber { get; private set; }

        [MaxLength(UserInvariants.SignatureMaxLength)]
        public string Signature { get; private set; }

        [MaxLength(UserInvariants.LanguageMaxLength)]
        public string Language { get; private set; }

        public string ProfilPicture { get; private set; }
        #endregion

        #region Constructors

        protected User() { }
        protected User(string email = "", string phoneNumber = "", string signature = "", string language = "", string profilPicture = "", string applicationUserId = "")
        {
            UpdateEmail(email);
            UpdatePhoneNumber(phoneNumber);
            UpdateSignature(signature);
            UpdateLanguage(language);
            UpdateProfilPicture(profilPicture);
            UpdateApplicationUserId(applicationUserId);
        }
        #endregion

        #region Methods
        public void UpdateEmail(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be empty.");

            if (value.Length > UserInvariants.EmailMaxLength)
                throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum email length ({UserInvariants.EmailMaxLength}).");

            Email = value;
        }  
        public void UpdatePhoneNumber(string value)
        {
               if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("PhoneNumber cannot be empty.");

            if (value.Length > UserInvariants.PhoneNumberMaxLength)
                throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum phone number length ({UserInvariants.PhoneNumberMaxLength}).");

            PhoneNumber = value;
        }

        public void UpdateSignature(string value)
        {
            if (value.Length > UserInvariants.SignatureMaxLength)
                throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum signature length ({UserInvariants.SignatureMaxLength}).");

            Signature = value;
        }

        public void UpdateLanguage(string value)
        {
            if (value.Length > UserInvariants.LanguageMaxLength)
                throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum language length ({UserInvariants.LanguageMaxLength}).");

            Language = value;
        }

        public void UpdateProfilPicture(string value)
        {
            if(string.IsNullOrWhiteSpace(value))      
                throw new ArgumentException("ProfilPicture cannot be empty.");

            ProfilPicture = value;
        }

        public void UpdateApplicationUserId(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("ApplicationUserId cannot be empty.");
            ApplicationUserId = value;
        }
        #endregion


    }
}
