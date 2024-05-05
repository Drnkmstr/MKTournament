using MKTournament.Application.Abstractions.Messaging;
using MKTournament.Domain.Abstractions;
using MKTournament.Domain.Common;
using MKTournament.Domain.Players;

namespace MKTournament.Application.Players.GetPlayer;

public class GetPlayerQueryHandler(
    IPlayerRepository playerRepository) 
    : IQueryHandler<GetPlayerQuery, GetPlayerResponse>
{
    public async Task<Result<GetPlayerResponse>> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
    {
        var player = await playerRepository.GetByIdAsync(request.Id, cancellationToken);

        return player is not null
            ? Result.Success(new GetPlayerResponse
            {
                Id = player.Id,
                NickName = player.NickName.Value,
                Email = player.EmailAddress.Value
            })
            : Result.Failure<GetPlayerResponse>(GenericEntityError.NotFound<Player>());
    }
}