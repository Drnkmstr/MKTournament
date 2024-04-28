using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKTournament.Domain.Races;

namespace MKTournament.Infrastructure.Persistence.Configurations;

public class RaceConfigurations : IEntityTypeConfiguration<Race>
{
    public void Configure(EntityTypeBuilder<Race> builder)
    {
        builder.HasKey(p => p.Id);
    }
}