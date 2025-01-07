using CakeShopProject.Domain.Entities;
using CakeShopProject.Domain.Enum;
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
        builder.Property(x => x.OrderStatus).IsRequired();
        builder.Property(x => x.Discount);
        builder.Property(x=>x.TotalAmount).IsRequired();

        // Relacionamento de um Client para varios Orders
        builder.HasOne(x => x.Client).WithMany(x => x.Orders).HasForeignKey(x => x.ClientId);
        #region Default
        builder.Property(x => x.DataCreated);
        builder.Property(x => x.UserIdCreated).HasMaxLength(50);
        builder.Property(u => u.DateModified);
        builder.Property(u => u.UserIdModified).HasMaxLength(50);

        builder.Property(u => u.DateDeleted);
        builder.Property(u => u.UserIdDeleted).HasMaxLength(50);

        //Enum
        builder.Property(x => x.Situation).IsRequired().HasDefaultValueSql("1");
        #endregion

    }
}
