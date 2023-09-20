using MyTicketRemaster.Domain.Common;

namespace MyTicketRemaster.Domain.Entities.Priorities
{
    public class Priority : MyEntity
    {
        [Required]
        [MaxLength(PriorityInvariants.NameMaxLength)]
        public string Name { get; private set; }
        public bool Editable { get; private set; }

        public Priority() { }
        public Priority(string name, bool editable = true)
        {
            UpdateName(name);
            Editable = editable;
        }

        public void UpdateName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty.");

            if (value.Length > PriorityInvariants.NameMaxLength)
                throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum name length ({PriorityInvariants.NameMaxLength}).");

            Name = value;
        }   
    }
}
