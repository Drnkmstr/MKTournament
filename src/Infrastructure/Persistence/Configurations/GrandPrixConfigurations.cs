using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class GrandPrixConfigurations : IEntityTypeConfiguration<GrandPrix>
{
    public void Configure(EntityTypeBuilder<GrandPrix> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Type)
            .HasMaxLength(20);
        
        builder.Property(p => p.ObjectMode)
            .HasMaxLength(20);
        
        builder.Property(p => p.AiMode)
            .HasMaxLength(20);

        builder.HasMany<Race>()
            .WithOne()
            .HasForeignKey(p => p.GrandPrixId)
            .IsRequired();
    }
}