using MKTournament.Application.Abstractions.Messaging;
using MKTournament.Domain.Abstractions;
using MKTournament.Domain.Players;

namespace MKTournament.Application.Players.RegisterPlayer;

public class CreatePlayerCommandHandler(
    IPlayerRepository playerRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreatePlayerCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var player = Player.Create(
            PlayerNickName.From(request.NickName),
            PlayerEmailAddress.From(request.Email));

        var result = await playerRepository.Add(player, cancellationToken);

        if (result.IsFailure)
        {
            return Result.Failure<Guid>(result.Error);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return player.Id;
    }
}