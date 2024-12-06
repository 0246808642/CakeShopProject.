using CakeShopProject.Data.Repository.Base;
using CakeShopProject.Domain.Entities;
using CakeShopProject.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace CakeShopProject.Data.Repository;

public class CityRepository : BaseRepository<City>, ICityRepository
{
    public CityRepository(DbContext context) : base(context)
    {
    }
}
