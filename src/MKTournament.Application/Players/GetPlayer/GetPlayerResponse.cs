namespace MKTournament.Application.Players.GetPlayer;

public sealed class GetPlayerResponse
{
    public required Guid Id { get; init; }
    
    public required string NickName { get; init; }
    
    public required string Email { get; init; }
}