using MyTicketRemaster.Domain.Common;

namespace MyTicketRemaster.Domain.Entities.Status
{
    public class TStatus : MyEntity
    {
        [Required]
        [StringLength(StatusInvariants.NameMaxLength)]
        public string Name { get; private set; } = null!;
        public bool Editable { get; set; }

        public TStatus(string name, bool editable = true) 
        { 
            UpdateName(name);
            Editable = editable;
        }

        public void UpdateName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty.");

            if (value.Length > StatusInvariants.NameMaxLength)
                throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum name length ({StatusInvariants.NameMaxLength}).");

        }   
    }
}
