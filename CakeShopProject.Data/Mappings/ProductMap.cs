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
        builder.Property(x=> x.Size).IsRequired().HasDefaultValue("1");
        builder.Property(x=>x.Flavor).IsRequired().HasDefaultValue("1");
        builder.Property(x=> x.Price).IsRequired();

        // Relacionamento
        builder.HasOne(x=>x.Orders).WithMany(x=>x.Product).HasForeignKey(x=>x.OrdersId);    
    }
}
