using MyTicketRemaster.Application.Dependencies.Services;

namespace MyTicketRemaster.Infrastructure.ApplicationDependencies.Services;

internal class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
