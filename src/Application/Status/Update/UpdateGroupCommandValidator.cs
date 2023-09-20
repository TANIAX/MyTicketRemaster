using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

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
                .MaximumLength(30).WithMessage("Name must not exceed 30 characters");
        }
    }
}
