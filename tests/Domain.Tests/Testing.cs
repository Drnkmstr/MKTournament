using Bogus;
using MKTournament.Domain.Enums;
using MKTournament.Domain.GrandPrixx;
using MKTournament.Domain.Maps;

namespace Domain.Tests;

[SetUpFixture]
public class Testing
{
    public static Faker FakeGenerator = null!;

    public static Faker<Map> FakeMap = null!;
    public static Faker<GrandPrix> FakeGrandPrix = null!;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        FakeGenerator = new Faker();

        FakeMap = new Faker<Map>()
            .CustomInstantiator(f => 
                new Map(Guid.NewGuid(), MapName.From(f.Commerce.Product())));

        FakeGrandPrix = new Faker<GrandPrix>()
            .CustomInstantiator(f => 
                new GrandPrix(
                    Guid.NewGuid(),
                    f.PickRandom(GrandPrixType.GetAll<GrandPrixType>()),
                    false,
                    f.PickRandom(ObjectMode.GetAll<ObjectMode>()),
                    f.PickRandom(AiMode.GetAll<AiMode>()),
                    f.PickRandom(GrandPrixRaceNumber.GetAll<GrandPrixRaceNumber>())
                    ));
    }
}