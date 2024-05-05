using MKTournament.Application.Abstractions.Messaging;

namespace MKTournament.Application.Players.GetPlayer;

public sealed record GetPlayerQuery(Guid Id) : IQuery<GetPlayerResponse>;