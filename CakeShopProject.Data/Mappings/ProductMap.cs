using CakeShopProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CakeShopProject.Data.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");
        builder.HasKey(x=> x.Id);

        builder.Property(x => x.Name).HasMaxLength(80).IsRequired();
        builder.Property(x => x.Size).IsRequired();
        builder.Property(x => x.Flavor).IsRequired();
        builder.Property(x=> x.Price).IsRequired();

        // Relacionamento
        builder.HasOne(x=>x.Orders).WithMany(x=>x.Product).HasForeignKey(x=>x.OrdersId);
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
