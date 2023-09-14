using MyTicketRemaster.Domain.Common;

namespace MyTicketRemaster.Domain.Entities.Status
{
    public class TStatus : MyEntity
    {
        [Required]
        [StringLength(StatusInvariants.NameMaxLength)]
        public string Name { get; private set; }
        public bool Editable { get; private set; }
    }
}
