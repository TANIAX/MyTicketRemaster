namespace MyTicketRemaster.Infrastructure.Authentication.External.Model;

public record ExternalUserData
{
    public string Email { get; set; } 
    public bool EmailVerified { get; set; }
    public string FullName { get; set; } 
    public string FirstName { get; set; }
    public string LastName { get; set; } 
}
