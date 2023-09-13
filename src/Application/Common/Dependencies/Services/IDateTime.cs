using System;

namespace MyTicketRemaster.Application.Dependencies.Services;

public interface IDateTime
{
    DateTime Now { get; }
}
