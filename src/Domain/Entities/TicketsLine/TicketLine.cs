﻿using MyTicketRemaster.Domain.Common;
using MyTicketRemaster.Domain.Entities.Users;

namespace MyTicketRemaster.Domain.Entities.TicketsLine
{
    public class TicketLine : MyEntity
    {
        public string Content { get; private set; }
        public bool AskForClose { get; private set; }
        public string Email { get; private set; }
        
        public virtual Guid ResponseById { get; private set; }
    }
}