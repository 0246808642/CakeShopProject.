using CakeShopProject.Domain.Entities.Base;
using CakeShopProject.Domain.Enum;

namespace CakeShopProject.Domain.Entities;
/// <summary>
/// Produtos
/// </summary>
public class Product : EntityBase
{
    public string Name { get; set; }
    public Size? Size { get; set; } 
    public Flavor? Flavor { get; set; }
    public decimal Price { get; set; }

    // Relacionamento
    public long OrdersId { get; set; }
    public Orders Orders { get; set; }
}
