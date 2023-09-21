using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using MyTicketRemaster.Domain.Entities.Groups;

namespace MyTicketRemaster.Application.Groups.Update;

    public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
{
    public UpdateGroupCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required");

        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(GroupInvariants.NameMaxLength).WithMessage($"Name must not exceed {GroupInvariants.NameMaxLength} characters");
    }
}

