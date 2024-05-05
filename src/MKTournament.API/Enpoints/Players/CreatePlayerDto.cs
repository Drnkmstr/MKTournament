namespace MKTournament.API.Enpoints.Players;

public record CreatePlayerDto(
    string Email,
    string NickName,
    string Password);