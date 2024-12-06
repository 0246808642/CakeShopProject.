using CakeShopProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CakeShopProject.Data.Mappings;

public class StateMap : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable("State");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        builder.Property(x=> x.Uf).HasMaxLength(2).IsRequired();


    }
}
