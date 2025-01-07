using CakeShopProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CakeShopProject.Data.Mappings;

public class ClientMap : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Client");
        builder.HasKey(x =>x.Id);

        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x=> x.Telephone).HasMaxLength(15).IsRequired();
        builder.Property(x=>x.Email).HasMaxLength(100).IsRequired();
        builder.Property(x=>x.DataOfBirth).HasMaxLength(10).IsRequired();
        builder.Property(x=>x.Cpf).HasMaxLength(14).IsRequired();
        builder.Property(x=>x.Address).HasMaxLength(120).IsRequired();
        builder.Property(x=>x.NumberOfHouse).HasMaxLength(10).IsRequired();
        builder.Property(x=>x.ZipCode).HasMaxLength(9).IsRequired();

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

        // Relacionamento de uma cidade pode ter varios clientes
        builder.HasOne(x => x.City).WithMany(x=> x.Client).HasForeignKey(x => x.CityId);

    }
}
