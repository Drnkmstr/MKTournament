using MKTournament.Domain.Errors.MapExceptions;
using FluentAssertions;
using MKTournament.Domain.Maps;

// ReSharper disable StringLiteralTypo

namespace Domain.Tests.ValueObjects;

[TestFixture]
public class MapNameTests
{
    private MapName _playerNickName = null!;
    
    [Test]
    [TestCase("Drunkenmaster")]
    [TestCase("Dr")]
    public void ShouldInstantiate(string name)
    {
        _playerNickName = MapName.From(name);
        _playerNickName.Value.Should().Be(name);
    }
    
    [Test]
    // Too short
    [TestCase("o")]
    // Too long
    [TestCase("oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo")]
    public void ShouldThrow(string name)
    {
        Assert.Throws<InvalidMapNameException>(() =>
        {
            MapName.From(name);
        });
    }
}