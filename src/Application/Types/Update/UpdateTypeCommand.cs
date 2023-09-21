using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Domain.Entities.Types;

namespace MyTicketRemaster.Application.Types.Update;

    public record UpdateTypeCommand : IRequest<TType>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public class UpdateTypeCommandHandler : IRequestHandler<UpdateTypeCommand, TType>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TType> Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
        {
            var type = await _unitOfWork.Types.GetByIdAsync(request.Id)
                 ?? throw new EntityNotFoundException(nameof(TType), request.Id);

            type.UpdateName(request.Name.Trim());

            await _unitOfWork.SaveChanges();

            return type;
        }
    }
}


