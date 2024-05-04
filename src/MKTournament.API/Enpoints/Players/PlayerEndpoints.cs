using MediatR;
using MKTournament.Application.Players.RegisterPlayer;
using MKTournament.Domain.Abstractions;
using MKTournament.Domain.Players;

namespace MKTournament.API.Enpoints.Players;

public static class PlayerEndpoints
{
    private const string BaseRoute = "players";
    
    public static void MapPlayersEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapPost(BaseRoute, async (
            CreatePlayerRequest playerRequest,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new CreatePlayerCommand(
                playerRequest.Email,
                playerRequest.NickName,
                playerRequest.Password);

            var result = await sender.Send(command, cancellationToken);

            return result.IsFailure
                ? Results.BadRequest(result.Error)
                : Results.CreatedAtRoute($"{BaseRoute}/{result.Value.ToString()}");
        });
    }
}