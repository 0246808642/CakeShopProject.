using CakeShopProject.Domain.Entities;
using FluentValidation;

namespace CakeShopProject.CrossCutting.DependencyInjection.Validation;

public class OrdersValidator : AbstractValidator<Orders>
{
    public OrdersValidator()
    {
     
    }
}
