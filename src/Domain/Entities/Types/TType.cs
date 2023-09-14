using MyTicketRemaster.Domain.Common;

namespace MyTicketRemaster.Domain.Entities.Types
{
    public class TType : MyEntity
    {
        [Required]
        [StringLength(TypeInvariants.NameMaxLength)]
        public string Name { get; private set; }
        public bool Editable { get; private set; }
    }
}
