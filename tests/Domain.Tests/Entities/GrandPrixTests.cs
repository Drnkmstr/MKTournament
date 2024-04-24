using MKTournament.Domain.Enums;
using FluentAssertions;
using MKTournament.Domain.GrandPrixx;

namespace Domain.Tests.Entities;

using static Testing;

[TestFixture]
public class GrandPrixTests
{
    [Test]
    public void DefaultInitialization()
    {
        var gp = new GrandPrix(Guid.NewGuid());

        gp.Type.Should().Be(GrandPrixType.Gp150.Value);
        gp.ObjectMode.Should().Be(ObjectMode.Normal.Value);
        gp.AiMode.Should().Be(AiMode.Normal.Value);
        gp.RaceCount.Should().Be(GrandPrixRaceNumber.R4.Value);
        gp.TeamMode.Should().BeFalse();
        gp.Date.Should().BeCloseTo(DateTime.Now, new TimeSpan(0,0,0,0,20));
    }

    [Test]
    public void Generate()
    {
        var gp = FakeGrandPrix.Generate();
    }
}