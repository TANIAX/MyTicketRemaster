using MyTicketRemaster.Domain.Common;

namespace MyTicketRemaster.Domain.Entities.TicketsLine
{
    public class TicketLine : MyEntity
    {
        [Required]
        public string Content { get; private set; }
        public bool AskForClose { get; private set; }

        [MaxLength(TicketLineInvariants.EmailMaxLength)]
        public string Email { get; private set; }
        
        public Guid ResponseById { get; private set; }

        public TicketLine() { }
    }
}
