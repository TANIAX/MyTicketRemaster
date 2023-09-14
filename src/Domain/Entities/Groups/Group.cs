using MyTicketRemaster.Domain.Common;

namespace MyTicketRemaster.Domain.Entities.Groups
{
    /// <summary>
    /// Value object representing a Group.
    /// </summary>
    public class TGroup : MyEntity
    {
        [Required]
        [StringLength(GroupInvariants.NameMaxLength)]
        public string Name { get; private set; }
    }
}
