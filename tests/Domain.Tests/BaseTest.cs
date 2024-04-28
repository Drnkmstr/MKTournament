using MKTournament.Domain.Common;

namespace Domain.Tests;

public abstract class BaseTest
{
    internal static T AssertDomainEventWasPublished<T>(BaseEntity entity)
    {
        var domainEvent = entity.GetDomainEvents().OfType<T>().SingleOrDefault();

        if (domainEvent is null)
        {
            throw new Exception($"{typeof(T).Name} was not published");
        }

        return domainEvent;
    }
}