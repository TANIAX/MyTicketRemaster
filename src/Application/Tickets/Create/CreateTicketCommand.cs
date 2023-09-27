using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Application.Dependencies.Services;
using MyTicketRemaster.Domain.Entities.TicketsHeader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicketRemaster.Application.Tickets.Create
{
    public record CreateTicketCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }


        public CreateTicketCommand(string title, string description)
        {
            Title = title;
            Description = description;
        }      
    }

    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, int>
    {
        private readonly IApplicationSettings _settings;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public CreateTicketCommandHandler(IApplicationSettings settings, IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _settings = settings;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }
        public async Task<int> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = new TicketHeader();

            ticket.UpdateTitle(request.Title);
            ticket.UpdateDescription(request.Description);
            ticket.UpdatePriority(await _unitOfWork.Priorities.GetByIdAsync(_settings.defautPriorityId)
                                        ?? throw new EntityNotFoundException("Default Priority not found"));
            ticket.UpdateProject(await _unitOfWork.Projects.GetByIdAsync(_settings.defautProjectId)
                                       ?? throw new EntityNotFoundException("Default Project not found"));
            ticket.UpdateStatus(await _unitOfWork.Status.GetByIdAsync(_settings.defautStatusId)
                                       ?? throw new EntityNotFoundException("Default Status not found"));
            ticket.UpdateType(await _unitOfWork.Types.GetByIdAsync(_settings.defautTypeId)
                                       ?? throw new EntityNotFoundException("Default Type not found"));
            ticket.UpdateRequester(await _unitOfWork.Customers.GetCustomerByUserIdAsync(_currentUserService.UserId)
                                       ?? throw new EntityNotFoundException("Current user not found"));

            return 1;

        }
    }
}
