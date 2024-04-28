using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKTournament.Domain.Maps;
using MKTournament.Domain.Races;

namespace MKTournament.Infrastructure.Persistence.Configurations;

public class MapConfigurations : IEntityTypeConfiguration<Map>
{
    public void Configure(EntityTypeBuilder<Map> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(MapName.MaxLength);

        builder.HasMany<Race>()
            .WithOne()
            .HasForeignKey(p => p.MapId);
    }
}