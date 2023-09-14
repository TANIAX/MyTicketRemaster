using MyTicketRemaster.Domain.Common;

namespace MyTicketRemaster.Domain.Entities.Projects
{
    public class Project : MyEntity
    {
        [Required]
        [StringLength(ProjectInvariants.NameMaxLength)]
        public string Name { get; private set; }
        public bool Editable { get; private set; }
    }
}
