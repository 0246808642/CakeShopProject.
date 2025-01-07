namespace CakeShopProject.Domain.Enum;

public enum OrderStatus : byte
{
    Pending = 1,
    Paid,
    Shipped,
    Canceled,

}
