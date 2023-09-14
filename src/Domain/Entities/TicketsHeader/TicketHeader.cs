using MyTicketRemaster.Domain.Common;
using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Domain.Entities.Priorities;
using MyTicketRemaster.Domain.Entities.Projects;
using MyTicketRemaster.Domain.Entities.Status;
using MyTicketRemaster.Domain.Entities.TicketsLine;
using MyTicketRemaster.Domain.Entities.Types;
using MyTicketRemaster.Domain.Entities.Users;
using MyTicketRemaster.Domain.Entities.Users.Customers;
using MyTicketRemaster.Domain.Entities.Users.Employees;

namespace MyTicketRemaster.Domain.Entities.TicketsHeader
{
    public class TicketHeader : MyEntity
    {
        public string Title { get; private set; }
        public string InternTitle { get; private set; }
        public string Description { get; private set; }
        public string Email { get; private set; }
        public int Read { get; private set; }
        public int Satisfaction { get; private set; }
        
        public virtual Employee AssignTO { get; private set; }
        public virtual Customer Requester { get; private set; }
        public virtual TGroup Group { get; private set; }
        public virtual TStatus Status { get; private set; }
        public virtual Priority Priority { get; private set; }
        public virtual Project Project { get; private set; }
        public virtual TType Type { get; private set; }
        public virtual ICollection<TicketLine> TicketLines { get; private set; }
    }
}
