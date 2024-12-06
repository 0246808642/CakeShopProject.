using CakeShopProject.Data.Repository.Base;
using CakeShopProject.Domain.Entities;
using CakeShopProject.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace CakeShopProject.Data.Repository;

public class ClientRepository : BaseRepository<Client>, IClienteRepository
{
    public ClientRepository(DbContext context) : base(context)
    {
    }
}
