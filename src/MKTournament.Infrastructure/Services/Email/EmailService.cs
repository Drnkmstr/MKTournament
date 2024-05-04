using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;
using MKTournament.Application.Abstractions.Email;
using MKTournament.Domain.Players;

namespace MKTournament.Infrastructure.Services.Email;

public class EmailService(ILogger<EmailService> logger) : IEmailService
{
    public Task SendAsync(PlayerEmailAddress recipient, string subject, string body)
    {
        logger.LogInformation($"Sending email to {recipient.Value}. Subject : {subject} Body : {body}");

        return Task.CompletedTask;
    }
}