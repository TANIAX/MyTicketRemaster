﻿namespace MyTicketRemaster.Infrastructure.Authentication.External.Exceptions;

public class ExternalAuthenticationSetupException : Exception
{
    public ExternalAuthenticationSetupException(string provider)
        : base($"External provider '{provider}' is not set up properly for authentication.")
    { }
}
