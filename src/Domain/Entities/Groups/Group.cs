using MyTicketRemaster.Domain.Common;

namespace MyTicketRemaster.Domain.Entities.Groups
{
    public class TGroup : MyEntity
    {
        [Required]
        [MaxLength(GroupInvariants.NameMaxLength)]
        public string Name { get; private set; } 

        public TGroup() { }
        public TGroup(string name)
        {
            UpdateName(name);
        }

        public void UpdateName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty.");

            if (value.Length > GroupInvariants.NameMaxLength)
                throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum name length ({GroupInvariants.NameMaxLength}).");

            Name = value;
        }
    }
}
