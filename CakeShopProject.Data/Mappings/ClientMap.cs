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

        // Relacionamento de uma cidade pode ter varios clientes
        builder.HasOne(x => x.City).WithMany(x=> x.Client).HasForeignKey(x => x.CityId);

    }
}
