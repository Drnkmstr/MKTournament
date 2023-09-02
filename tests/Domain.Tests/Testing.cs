using Bogus;

namespace Domain.Tests;

[SetUpFixture]
public class Testing
{
    public static Faker FakeGenerator;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        FakeGenerator = new Faker();
    }
}