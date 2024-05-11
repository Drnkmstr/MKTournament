using MKTournament.Application.Abstractions.Messaging;
using MKTournament.Domain.Abstractions;
using MKTournament.Domain.Players;
using MKTournament.Domain.Players.Errors;

namespace MKTournament.Application.Players.RegisterPlayer;

// ReSharper disable once UnusedType.Global
public class CreatePlayerCommandHandler(
    IPlayerRepository playerRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreatePlayerCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var playerEmail = PlayerEmailAddress.From(request.Email);
        
        if (await playerRepository.IsEmailAlreadyTakenAsync(playerEmail, cancellationToken))
        {
            return Result.Failure<Guid>(PlayerError.EmailAlreadyTaken(playerEmail));
        }
        
        var playerNickName = PlayerNickName.From(request.NickName);
        
        if (await playerRepository.IsNickNameAlreadyTakenAsync(playerNickName, cancellationToken))
        {
            return Result.Failure<Guid>(PlayerError.NickNameAlreadyTaken(playerNickName));
        }
        
        var player = Player.Create(
            PlayerNickName.From(request.NickName),
            PlayerEmailAddress.From(request.Email));
        
        playerRepository.Add(player);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return player.Id;
    }
}