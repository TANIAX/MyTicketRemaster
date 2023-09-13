using MyTicketRemaster.Infrastructure.Common.Validation;
using System.Diagnostics.CodeAnalysis;

namespace MyTicketRemaster.Infrastructure.Persistence.Settings;

class UserSeedSettings
{
    [MemberNotNullWhen(true, nameof(DefaultUsername), nameof(DefaultPassword))]
    public bool SeedDefaultUser { get; init; }
    
    [RequiredIf(nameof(SeedDefaultUser), true)]
    public string? DefaultUsername { get; init; }

    [RequiredIf(nameof(SeedDefaultUser), true)]
    public string? DefaultPassword { get; init; }

    public string DefaultEmail { get; init; } = null!;
}
