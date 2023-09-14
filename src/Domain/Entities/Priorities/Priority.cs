using MyTicketRemaster.Domain.Common;

namespace MyTicketRemaster.Domain.Entities.Priorities
{
    public class Priority : MyEntity
    {
        [Required]
        [StringLength(PriorityInvariants.NameMaxLength)]
        public string Name { get; private set; }
        public bool Editable { get; private set; }
    }
}
