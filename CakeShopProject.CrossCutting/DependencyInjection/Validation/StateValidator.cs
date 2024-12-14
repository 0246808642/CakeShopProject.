using CakeShopProject.Domain.Entities;
using FluentValidation;

namespace CakeShopProject.CrossCutting.DependencyInjection.Validation;

public class StateValidator : AbstractValidator<State>
{
    public StateValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome do estado é obrigatório")
            .MaximumLength(21).WithMessage("Máximo do campo é de 21 caracteres")
            .MinimumLength(2).WithMessage("Minímo do campo é de 2 caracteres");

        RuleFor(x => x.Uf)
            .NotEmpty().WithMessage("O Uf do estado é obrigatório")
            .MaximumLength(2).WithMessage("Máximo do campo é de 2 caracteres")
            .MinimumLength(2).WithMessage("Minímo do campo é de 2 caracteres");
    }
}
