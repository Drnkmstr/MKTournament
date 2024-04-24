using MediatR;

namespace Application.Players.Commands;

public record CreatePlayerCommand(string NickName, string EmailAddress) : IRequest;

