using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Domain.Entities.StoredReplies;
using MyTicketRemaster.Domain.Entities.Users.Employee;
using System.Text.RegularExpressions;
namespace MyTicketRemaster.Domain.Entities.Users.Employees
{
    public class Employee : User
    {
        #region Properties
        [Required]
        [MaxLength(EmployeeInvariants.FirstNameMaxLength)]
        public string FirstName { get; private set; }

        [Required]
        [MaxLength(EmployeeInvariants.LastNameMaxLength)]
        public string LastName { get; private set; }

        [Required]
        public virtual TGroup Group { get; private set; }
        public virtual ICollection<StoredReply> StoredReply { get; private set; }

        #endregion

        #region Constructors
        public Employee(): base()
            => StoredReply = new List<StoredReply>();
        

        public Employee(string FirstName, string LastName, string email, string phoneNumber, string signature, string language, string profilPicture, string applicationUserId, TGroup group = null) 
            : base(email, phoneNumber, signature, language, profilPicture, applicationUserId)
        {
            UpdateFirstName(FirstName);
            UpdateLastName(LastName);
            UpdateGroup(group);
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

        public void UpdateGroup(TGroup group)
        {
            Group = group ?? throw new ArgumentNullException(nameof(Group));
        }

        public void AddStoredReply(StoredReply storedReply)
        {
            if (storedReply == null)
                throw new ArgumentNullException(nameof(storedReply));

            StoredReply.Add(storedReply);
        }

        public void RemoveStoredReply(StoredReply storedReply)
        {
            if (storedReply == null)
                throw new ArgumentNullException(nameof(storedReply));

            StoredReply.Remove(storedReply);
        }

        #endregion

    }
}
