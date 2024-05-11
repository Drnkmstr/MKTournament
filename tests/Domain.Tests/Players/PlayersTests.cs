using FluentAssertions;
using MKTournament.Domain.Players;
using MKTournament.Domain.Players.Errors;
using MKTournament.Domain.Players.Events;
using static Domain.Tests.Testing;

namespace Domain.Tests.Players;

public class PlayersTests : BaseTest
{
    private Player _player;
    
    [SetUp]
    public void PlayerSetup()
    {
        _player = FakePlayer.Generate();
    }
    
    [Test]
    public void Create_Should_Raise_PlayerCreatedDomainEvent()
    {
        var domainEvent = AssertDomainEventWasPublished<PlayerCreatedDomainEvent>(_player);

        domainEvent.PlayerId.Should().Be(_player.Id);
    }

    [Test]
    public void ConfirmEmail_Should_Raise_PlayerConfirmedDomainEvent()
    {
        var result = _player.ConfirmEmail(_player.RegistrationToken);

        var domainEvent = AssertDomainEventWasPublished<PlayerConfirmedDomainEvent>(_player);

        result.IsSuccess.Should().BeTrue();
        domainEvent.PlayerId.Should().Be(_player.Id);
    }

    [Test]
    public void ConfirmEmail_Should_ReturnError_WhenCalledMoreThanOnce()
    {
        _player.ConfirmEmail(_player.RegistrationToken);
        var result = _player.ConfirmEmail(_player.RegistrationToken);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(PlayerError.EmailAlreadyConfirmed(_player.EmailAddress));
    }
}