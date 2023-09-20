using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Domain.Entities.Priorities;

namespace MyTicketRemaster.Application.Priorities.Update;

public record UpdatePriorityCommand : IRequest<Priority>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public class UpdatePriorityCommandHandler : IRequestHandler<UpdatePriorityCommand, Priority>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePriorityCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Priority> Handle(UpdatePriorityCommand request, CancellationToken cancellationToken)
        {
            var priority = await _unitOfWork.Priorities.GetByIdAsync(request.Id)
                 ?? throw new EntityNotFoundException(nameof(Priority), request.Id);

            priority.UpdateName(request.Name.Trim());

            await _unitOfWork.SaveChanges();

            return priority;
        }
    }
}


