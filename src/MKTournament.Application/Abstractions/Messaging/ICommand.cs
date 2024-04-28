using MediatR;
using MKTournament.Domain.Abstractions;

namespace MKTournament.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;