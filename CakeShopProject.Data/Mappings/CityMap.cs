using CakeShopProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CakeShopProject.Data.Mappings;

public class CityMap : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("City");
        builder.HasKey(x => x.Id);

        builder.Property(x=>x.Name).HasMaxLength(80).IsRequired();
        builder.Property(x=>x.CodeCity).HasMaxLength(2).IsRequired();

        // Relacionamento de um State pra varias City
        builder.HasOne(x=>x.State).WithMany(x => x.City).HasForeignKey(x=>x.StateId);
    }
}
