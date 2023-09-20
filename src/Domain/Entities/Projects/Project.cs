using MyTicketRemaster.Domain.Common;

namespace MyTicketRemaster.Domain.Entities.Projects
{
    public class Project : MyEntity
    {
        [Required]
        [StringLength(ProjectInvariants.NameMaxLength)]
        public string Name { get; private set; } = null!;
        public bool Editable { get; set; }

        public Project(string name, bool editable = true)
        {
            UpdateName(name);
            Editable = editable;
        }

        public void UpdateName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty.");

            if (value.Length > ProjectInvariants.NameMaxLength)
                throw new ArgumentException($"Length of value ({value.Length}) exceeds maximum name length ({ProjectInvariants.NameMaxLength}).");

        }
    }
}
