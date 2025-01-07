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
