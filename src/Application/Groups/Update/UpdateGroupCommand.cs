using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Domain.Entities.Groups;

namespace MyTicketRemaster.Application.Groups.Update;

    public record UpdateGroupCommand : IRequest<TGroup>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, TGroup>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TGroup> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _unitOfWork.Groups.GetByIdAsync(request.Id)
                 ?? throw new EntityNotFoundException(nameof(TGroup), request.Id);

            group.UpdateName(request.Name.Trim());
            await _unitOfWork.SaveChanges();

            return group;
        }
    }
}


