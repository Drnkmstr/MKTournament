using MKTournament.Domain.Errors.PlayerExceptions;
using FluentAssertions;
using MKTournament.Domain.Players;

namespace Domain.Tests.ValueObjects;

using static Testing;

[TestFixture]
public class PlayerEmailAddressTests
{
    private PlayerEmailAddress _playerEmailAddress = null!;

    [Test]
    [Repeat(1000)]
    public void ShouldInstantiate()
    {
        var email = FakeGenerator.Internet.Email();

        _playerEmailAddress = PlayerEmailAddress.From(email);
        _playerEmailAddress.Value.Should().Be(email);
    }
    
    [Test]
    [Repeat(1000)]
    public void ShouldThrow()
    {
        var email = FakeGenerator.Person.UserName;

        Assert.Throws<InvalidPlayerEmailAddressException>(() =>
        {
            PlayerEmailAddress.From(email);
        });
    }
}