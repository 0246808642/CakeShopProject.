using CakeShopProject.Data.Repository.Base;
using CakeShopProject.Domain.Entities;
using CakeShopProject.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace CakeShopProject.Data.Repository;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(DbContext context) : base(context)
    {
    }
}
