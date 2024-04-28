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

        playerRepository.Add(player, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return player.Id;
    }
}