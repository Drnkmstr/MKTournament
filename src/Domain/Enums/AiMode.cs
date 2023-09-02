using Domain.Common;

namespace Domain.Enums;

public sealed class AiMode : Enumeration
{
    public static AiMode None = new(1, "No bots");
    public static AiMode Easy = new(2, "Easy bots");
    public static AiMode Normal = new(3, "Normal AI");
    public static AiMode Difficult = new(4, "Difficult AI");

    private AiMode(int id, string name) : base(id, name)
    {
    }
}