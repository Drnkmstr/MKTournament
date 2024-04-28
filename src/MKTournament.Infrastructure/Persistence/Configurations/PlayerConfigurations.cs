using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKTournament.Domain.Players;

namespace MKTournament.Infrastructure.Persistence.Configurations;

public class PlayerConfigurations : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.ToTable("players");
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.NickName)
            .HasConversion(
                nickName => nickName.Value, 
                value => PlayerNickName.From(value))
            .HasMaxLength(PlayerNickName.MaxLength);
        
        builder.Property(p => p.EmailAddress)
            .HasConversion(
                email => email.Value,
                value => PlayerEmailAddress.From(value))
            .HasMaxLength(PlayerEmailAddress.MaxLength);
        
        builder.HasIndex(p => p.EmailAddress)
            .IsUnique();

        builder.HasIndex(p => p.IdentityId)
            .IsUnique();
        
        builder.HasIndex(p => p.NickName)
            .IsUnique();
    }
}