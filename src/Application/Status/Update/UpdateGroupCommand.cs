using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Domain.Entities.Status;

namespace MyTicketRemaster.Application.Statuss.UpdatStatus;

    public record UpdateStatusCommand : IRequest<TStatus>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public class UpdateStatusCommandHandler : IRequestHandler<UpdateStatusCommand, TStatus>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStatusCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TStatus> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var status = await _unitOfWork.Status.GetByIdAsync(request.Id)
                 ?? throw new EntityNotFoundException(nameof(TStatus), request.Id);

            status.UpdateName(request.Name.Trim());
            status.Editable = true;

            await _unitOfWork.SaveChanges();

            return status;
        }
    }
}


