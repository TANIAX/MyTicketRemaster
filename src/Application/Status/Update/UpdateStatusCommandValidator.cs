using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using MyTicketRemaster.Domain.Entities.Status;

namespace MyTicketRemaster.Application.Statuss.UpdatStatus
{
    public class UpdateStatusCommandValidator : AbstractValidator<UpdateStatusCommand>
    {
        public UpdateStatusCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Id is required");

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(StatusInvariants.NameMaxLength).WithMessage($"Name must not exceed {StatusInvariants.NameMaxLength} characters");
        }
    }
}
