using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKTournament.Domain.Races;

namespace MKTournament.Infrastructure.Persistence.Configurations;

public class RaceConfigurations : IEntityTypeConfiguration<PlayerRace>
{
    public void Configure(EntityTypeBuilder<PlayerRace> builder)
    {
        builder.HasKey(p => p.Id);
    }
}