namespace MKTournament.Domain.Players;

public static class PlayerTokenService
{
    public static string GenerateToken()
    {
        return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    }
}