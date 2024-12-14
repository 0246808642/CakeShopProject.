using CakeShopProject.Domain.Entities;
using FluentValidation;

namespace CakeShopProject.CrossCutting.DependencyInjection.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome é obrigatório.")
            .MaximumLength(50).WithMessage("O campo só aceita no máximo 50 caracteres.")
            .MinimumLength(3).WithMessage("O minímo do campo é de 3 caracteres.");

    }
}
