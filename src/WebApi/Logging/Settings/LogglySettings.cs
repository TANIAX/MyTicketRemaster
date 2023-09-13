using MyTicketRemaster.Infrastructure.Common.Validation;

namespace MyTicketRemaster.WebApi.Logging.Settings;

public class LogglySettings
{
    [Required]
    [MemberNotNullWhen(true, nameof(CustomerToken))]
    public bool? WriteToLoggly { get; init; }

    [RequiredIf(nameof(WriteToLoggly), true)]
    public string? CustomerToken { get; init; }
}
