using Domain.Entities;
using Domain.Enums;
using FluentAssertions;

namespace Domain.Tests.Entities;

[TestFixture]
public class GrandPrixTests
{
    [Test]
    public void Bleh()
    {
        var gp = new GrandPrix(
            "Gerciflet",
            GrandPrixType.Gp150);

        gp.Type.Should().Be(GrandPrixType.Gp150.Name);
    }
}