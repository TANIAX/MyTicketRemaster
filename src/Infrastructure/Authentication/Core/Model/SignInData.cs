namespace MyTicketRemaster.Infrastructure.Authentication.Core.Model;

public record SignInData
{
    public TokenModel Token { get; set; }
    public string Username { get; set; } 
    public string Email { get; set; }
    public bool IsExternalLogin => !string.IsNullOrWhiteSpace(ExternalAuthenticationProvider);
    public string? ExternalAuthenticationProvider { get; set; }
}
