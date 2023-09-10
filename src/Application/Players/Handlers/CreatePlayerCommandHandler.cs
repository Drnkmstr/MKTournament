using Application.Players.Commands;
using MediatR;

namespace Application.Players.Handlers;

public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand>
{
    
    
    public CreatePlayerCommandHandler()
    {
        
    }
    
    public async Task Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        
    }
}