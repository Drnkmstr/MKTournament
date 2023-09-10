using Domain.Entities;
using Domain.Enums;
using FluentAssertions;

namespace Domain.Tests.Entities;

[TestFixture]
public class GrandPrixTests
{
    [Test]
    public void DefaultInitialization()
    {
        var gp = new GrandPrix();

        gp.Type.Should().Be(GrandPrixType.Gp150.Value);
        gp.ObjectMode.Should().Be(ObjectMode.Normal.Value);
        gp.AiMode.Should().Be(AiMode.Normal.Value);
        gp.RacesNumber.Should().Be(GrandPrixRaceNumber.R4.Value);
        gp.TeamMode.Should().BeFalse();
        gp.Date.Should().BeCloseTo(DateTime.Now, new TimeSpan(0,0,0,0,20));
    }
}