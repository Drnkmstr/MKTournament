using Bogus;
using MKTournament.Domain.Enums;
using MKTournament.Domain.GrandPrixx;
using MKTournament.Domain.Maps;
using MKTournament.Domain.Players;

namespace Domain.Tests;

[SetUpFixture]
public class Testing
{
    public static Faker FakeGenerator = null!;

    public static Faker<Map> FakeMap = null!;
    public static Faker<GrandPrix> FakeGrandPrix = null!;

    public static Faker<Player> FakePlayer = null!;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        FakeGenerator = new Faker();

        FakeMap = new Faker<Map>()
            .CustomInstantiator(f => Map.Create(MapName.From(f.Commerce.Product())));

        FakeGrandPrix = new Faker<GrandPrix>()
            .CustomInstantiator(f => 
                GrandPrix.Create(
                    f.PickRandom(GrandPrixType.GetAll<GrandPrixType>()),
                    false,
                    f.PickRandom(ObjectMode.GetAll<ObjectMode>()),
                    f.PickRandom(AiMode.GetAll<AiMode>()),
                    f.PickRandom(GrandPrixRaceNumber.GetAll<GrandPrixRaceNumber>())
                    ));

        FakePlayer = new Faker<Player>()
            .CustomInstantiator(f => 
                Player.Create(
                    PlayerNickName.From(f.Internet.UserName()),
                    PlayerEmailAddress.From(f.Internet.Email())));
    }
}