using MediatR;
using MKTournament.Domain.Abstractions;

namespace MKTournament.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;