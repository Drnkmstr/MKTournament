using MediatR;
using MKTournament.Domain.Abstractions;

namespace MKTournament.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;