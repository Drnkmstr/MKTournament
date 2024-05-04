namespace MKTournament.API.Enpoints.Players;

public record CreatePlayerRequest(
    string Email,
    string NickName,
    string Password);