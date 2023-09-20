using MyTicketRemaster.Domain.Common;

namespace MyTicketRemaster.Domain.Entities.Types
{
    public class TType : MyEntity
    {
        [Required]
        [StringLength(TypeInvariants.NameMaxLength)]
        public string Name { get; private set; }
        public bool Editable { get; private set; }

        public TType() { }
        public TType(string name, bool editable = true)
        {
            UpdateName(name);
            Editable = editable;
        }

        public void UpdateName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty.");

            if (value.Length > TypeInvariants.NameMaxLength)
                throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum name length ({TypeInvariants.NameMaxLength}).");

            Name = value;
        }
    }
}
