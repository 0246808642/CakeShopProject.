using CakeShopProject.Domain.Entities;
using CakeShopProject.Domain.Interface.Service.Base;
using Microsoft.IdentityModel.Tokens;

namespace CakeShopProject.Domain.Interface.Service;

public interface IClientService : IServiceBase<Client>
{
    Task<List<ValidationFailure>> ValidateClient(Client entity);
}
