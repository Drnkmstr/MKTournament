using MKTournament.Application.Abstractions.Messaging;

namespace MKTournament.Application.Players.RegisterPlayer;

public record CreatePlayerCommand(
    string Email,
    string NickName,
    string Password)
    : ICommand<Guid>;