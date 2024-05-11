using MediatR;
using MKTournament.Application.Abstractions.Email;
using MKTournament.Domain.Abstractions;
using MKTournament.Domain.Players;
using MKTournament.Domain.Players.Events;

namespace MKTournament.Application.Players.RegisterPlayer;

public class PlayerCreatedDomainEventHandler(
    IPlayerRepository playerRepository,
    IUnitOfWork unitOfWork,
    IEmailService emailService)
    : INotificationHandler<PlayerCreatedDomainEvent>
{
    public async Task Handle(PlayerCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var player = await playerRepository.GetByIdAsync(notification.PlayerId, cancellationToken);

        if (player is null)
        {
            return;
        }

        await emailService.SendAsync(player.EmailAddress,
            PlayerMessages.PlayerCreated_Email_Body,
            string.Format(PlayerMessages.PlayerCreated_Email_Subject, "MK Tournament", $"link {player.RegistrationToken}"));
        
        player.RegistrationTokenSentOnUtc = DateTime.UtcNow;

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}