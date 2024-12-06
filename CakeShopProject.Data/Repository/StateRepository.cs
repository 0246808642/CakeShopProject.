using CakeShopProject.Data.Repository.Base;
using CakeShopProject.Domain.Entities;
using CakeShopProject.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace CakeShopProject.Data.Repository;

public class StateRepository : BaseRepository<State>, IStateRepository
{
    public StateRepository(DbContext context) : base(context)
    {
    }
}
