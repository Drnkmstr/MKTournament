using MKTournament.Domain.Errors.RaceExceptions;
using FluentAssertions;
using MKTournament.Domain.Races;

namespace Domain.Tests.ValueObjects;

[TestFixture]
public class RacePositionTests
{
    private RacePosition _position = null!;

    [Test]
    [TestCase(0, 0)]
    [TestCase(1, 15)]
    [TestCase(2, 12)]
    [TestCase(3, 10)]
    [TestCase(4, 9)]
    [TestCase(5, 8)]
    [TestCase(6, 7)]
    [TestCase(7, 6)]
    [TestCase(8, 5)]
    [TestCase(9, 4)]
    [TestCase(10,3)]
    [TestCase(11,2)]
    [TestCase(12,1)]
    public void ShouldHaveCorrectScore(int position, int score)
    {
        _position = RacePosition.From(position);
        _position.Score.Should().Be(score);
    }

    [Test]
    [TestCase(13)]
    [TestCase(-1)]
    [TestCase(1000)]
    public void ShouldThrow(int position)
    {
        Assert.Throws<InvalidRacePositionException>(() =>
        {
            RacePosition.From(position);
        });
    }
}