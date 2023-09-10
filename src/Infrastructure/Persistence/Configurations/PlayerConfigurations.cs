using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class PlayerConfigurations : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.EmailAddress)
            .HasMaxLength(PlayerEmailAddress.MaxLength);
        
        builder.HasIndex(p => p.EmailAddress)
            .IsUnique();
        
        builder.Property(p => p.NickName)
            .HasMaxLength(PlayerNickName.MaxLength);
        
        builder.HasIndex(p => p.NickName)
            .IsUnique();
    }
}