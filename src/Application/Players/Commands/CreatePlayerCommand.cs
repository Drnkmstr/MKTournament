using MediatR;
using Domain.Entities;

namespace Application.Players.Commands;

public record CreatePlayerCommand(string NickName, string EmailAddress) : IRequest;

