using Domain.Errors.PlayerExceptions;
using Domain.ValueObjects;
using FluentAssertions;
// ReSharper disable StringLiteralTypo

namespace Domain.Tests.ValueObjects;

[TestFixture]
public class PlayerNickNameTests
{
    private PlayerNickName _playerNickName = null!;
    
    [Test]
    [TestCase("Drunkenmaster")]
    [TestCase("Dr")]
    public void ShouldInstantiate(string name)
    {
        _playerNickName = PlayerNickName.From(name);
        _playerNickName.Value.Should().Be(name);
    }
    
    [Test]
    [TestCase("o")]
    [TestCase("oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo")]
    public void ShouldThrow(string name)
    {
        Assert.Throws<InvalidPlayerNickNameException>(() =>
        {
            PlayerNickName.From(name);
        });
    }
}