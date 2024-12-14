using CakeShopProject.Domain.Entities;
using FluentValidation;

namespace CakeShopProject.CrossCutting.DependencyInjection.Validation;

public class ClientValidator: AbstractValidator<Client>
{
    public ClientValidator()
    {
        RuleFor(x => x.Name)
             .NotEmpty().WithMessage("O nome do cliente é obrigatório.")
             .MaximumLength(100).WithMessage("O campo nome aceita no máximo 100 caracteres.")
             .MinimumLength(3).WithMessage("O campo nome aceita no mínimo 3 caracteres.");

        RuleFor(x => x.Telephone)
                     .NotEmpty().WithMessage("O numero de telefone é obrigatorio")
                     .MaximumLength(20).WithMessage("O tamanho maximo do campo é de 20 caracteres.")
                     .MinimumLength(20).WithMessage("O tamanho minimo do campo é de 20 caracteres.");

        RuleFor(x => x.Email)
          .NotEmpty().WithMessage("O email do cliente é obrigatório.")
          .MaximumLength(120).WithMessage("O campo email aceita no máximo 120 caracteres.")
          .MinimumLength(3).WithMessage("O campo nome aceita no mínimo 3 caracteres.");

        RuleFor(x => x.Cpf)
            .NotEmpty().WithMessage("O CPF do cliente é obrigatório.")
            .MaximumLength(14).WithMessage("O campo CPF aceita no máximo 14 caracteres.")
            .MinimumLength(14).WithMessage("O campo CPF aceita no mínimo 14 caracteres.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("O endereço é obrigatorio")
            .MaximumLength(200).WithMessage("O tamanho maximo do endereço é de 200 caracteres.")
            .MinimumLength(20).WithMessage("O tamanho minimo do campo endereço é de 20 caracteres.");

        RuleFor(x => x.NumberOfHouse)
           .NotEmpty().WithMessage("O numero da casa é obrigatorio")
           .MaximumLength(20).WithMessage("O tamanho maximo do campo é de 20 caracteres.")
           .MinimumLength(1).WithMessage("O tamanho minimo do campo é de 1 caracteres.");

        RuleFor(x => x.ZipCode)
          .NotEmpty().WithMessage("O Cep é obrigatorio")
          .MaximumLength(9).WithMessage("O tamanho maximo do campo é de 9 caracteres.")
          .MinimumLength(9).WithMessage("O tamanho minimo do campo é de 9 caracteres.");


    }


}
