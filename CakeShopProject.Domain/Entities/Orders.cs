using CakeShopProject.Domain.Entities.Base;
using CakeShopProject.Domain.Enum;


namespace CakeShopProject.Domain.Entities;
/// <summary>
/// Pedido
/// </summary>
public class Orders : EntityBase
{
    public DateTime? RequiredDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
    public decimal Discount { get; set; }
    public decimal TotalAmount { get; set; }

    // Relacionamento
    public virtual ICollection<Product> Product { get; set; }
    public long ClientId { get; set; }
    public Client Client { get; set; }
}
