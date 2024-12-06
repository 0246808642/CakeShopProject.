using CakeShopProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CakeShopProject.Data.Mappings;

public class OrdersMap : IEntityTypeConfiguration<Orders>
{
    public void Configure(EntityTypeBuilder<Orders> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(x=>x.Id);

        builder.Property(x=>x.RequiredDate).HasMaxLength(10).IsRequired();
        builder.Property(x=>x.ShippedDate).HasMaxLength(10).IsRequired();
        builder.Property(x => x.OrderStatus).HasMaxLength(8).IsRequired().HasDefaultValue("1");
        builder.Property(x => x.Discount);
        builder.Property(x=>x.TotalAmount).IsRequired();

        // Relacionamento de um Client para varios Orders
        builder.HasOne(x => x.Client).WithMany(x => x.Orders).HasForeignKey(x => x.ClientId);
       
    }
}
