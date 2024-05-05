using MKTournament.Domain.Abstractions;

namespace MKTournament.Domain.Common;

public sealed record GenericEntityError(string Code, string Name) 
    : Error(Code, Name)
{
    public static GenericEntityError NotFound<T>()
    where T : BaseEntity
    {
        return new GenericEntityError(
            $"{typeof(T).Name}.NotFound",
            string.Format(GenericErrors.EntitiyNotFound, typeof(T).Name));
    }
}