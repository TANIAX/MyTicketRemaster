﻿using Microsoft.Extensions.Logging;
using MyTicketRemaster.Application.Common.Exceptions;

namespace MyTicketRemaster.Application.Common.Behaviors;

public class ExceptionLoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest: IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;

    public ExceptionLoggingBehavior(ILogger<TRequest> logger)
        => _logger = logger;

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        try
        {
            return await next();
        }
        catch (InputValidationException ive)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogError(ive, "Validation error occurred in request '{RequestName}'\r\n\tRequestPayload: {@RequestPayload}\r\n\tErrors: {@Errors}.", requestName, request, ive.Errors);

            throw;
        }
        catch (Exception e)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogError(e, "Exception occurred in request '{RequestName}'\r\n\tRequestPayload: {@RequestPayload}", requestName, request);

            throw;
        }
    }
}
