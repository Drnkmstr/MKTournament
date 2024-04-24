using MKTournament.Domain.Common;

namespace MKTournament.Domain.Enums;

public sealed class AiMode : Enumeration<string>
{
    public static readonly AiMode None = new(1, "No bots");
    public static readonly AiMode Easy = new(2, "Easy bots");
    public static readonly AiMode Normal = new(3, "Normal AI");
    public static readonly AiMode Difficult = new(4, "Difficult AI");

    private AiMode(int id, string name) : base(id, name)
    {
    }
}