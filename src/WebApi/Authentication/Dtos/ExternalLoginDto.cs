using MyTicketRemaster.Infrastructure.Authentication.External.Model;

namespace MyTicketRemaster.WebApi.Authentication.Models.Dtos;

public record ExternalLoginDto
{
    public ExternalAuthenticationProvider Provider { get; init; }

    [Required, MinLength(1)]
    public string IdToken { get; init; } = null!;
}
