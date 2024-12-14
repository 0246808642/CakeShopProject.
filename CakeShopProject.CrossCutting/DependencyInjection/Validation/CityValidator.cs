using CakeShopProject.Domain.Entities;
using FluentValidation;

namespace CakeShopProject.CrossCutting.DependencyInjection.Validation;

public class CityValidator : AbstractValidator<City>
{
    public CityValidator()
    {
        RuleFor(x => x.Nome)
           .NotEmpty().WithMessage("O nome da cidade é obrigatório.")
            .MaximumLength(100).WithMessage("O campo cidade aceita no máximo 100 caracteres.")
            .MinimumLength(3).WithMessage("O campo cidade aceita no mínimo 3 caracteres.");
    }
}
