using MKTournament.Domain.Players;

namespace MKTournament.Application.Abstractions.Email;

public interface IEmailService
{
    Task SendAsync(PlayerEmailAddress recipient, string subject, string body);
}