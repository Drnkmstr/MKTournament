using MediatR;
using MKTournament.Application.Players.GetPlayer;
using MKTournament.Application.Players.RegisterPlayer;

namespace MKTournament.API.Enpoints.Players;

public static class PlayerEndpoints
{
    private const string BaseRoute = "players";
    
    public static void MapPlayersEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapPost(BaseRoute,  async (
            CreatePlayerDto playerRequest,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new CreatePlayerCommand(
                playerRequest.Email,
                playerRequest.NickName,
                playerRequest.Password);

            var result = await sender.Send(command, cancellationToken);

            return result.IsSuccess
                ? Results.CreatedAtRoute($"{BaseRoute}/{result.Value.ToString()}")
                : Results.NotFound();
        });

        builder.MapGet(BaseRoute + "/{id:guid}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            var request = new GetPlayerQuery(id);

            var result = await sender.Send(request, cancellationToken);
            
            return result.IsSuccess
                ? Results.Ok(result.Value)
                : Results.NotFound(result.Error);
        });
    }
}