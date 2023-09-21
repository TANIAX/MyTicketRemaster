using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using MyTicketRemaster.Domain.Entities.Types;

namespace MyTicketRemaster.Application.Types.Update;

    public class UpdateTypeCommandValidator : AbstractValidator<UpdateTypeCommand>
{
    public UpdateTypeCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required");

        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(TypeInvariants.NameMaxLength).WithMessage($"Name must not exceed {TypeInvariants.NameMaxLength} characters");
    }
}

