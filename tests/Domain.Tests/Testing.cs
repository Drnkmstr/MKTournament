using Bogus;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Tests;

[SetUpFixture]
public class Testing
{
    public static Faker FakeGenerator;

    public static Faker<Map> FakeMap = null!;
    public static Faker<GrandPrix> FakeGrandPrix = null!;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        FakeGenerator = new Faker();

        FakeMap = new Faker<Map>()
            .CustomInstantiator(f => 
                new Map(MapName.From(f.Commerce.Product())));

        FakeGrandPrix = new Faker<GrandPrix>()
            .CustomInstantiator(f => 
                new GrandPrix(
                    f.PickRandom(GrandPrixType.GetAll<GrandPrixType>()),
                    false,
                    f.PickRandom(ObjectMode.GetAll<ObjectMode>()),
                    f.PickRandom(AiMode.GetAll<AiMode>()),
                    f.PickRandom(GrandPrixRaceNumber.GetAll<GrandPrixRaceNumber>())
                    ));
    }
}