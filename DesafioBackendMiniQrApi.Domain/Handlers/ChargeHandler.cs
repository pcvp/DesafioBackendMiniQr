using DesafioBackendMiniQrApi.Domain.Commands;
using DesafioBackendMiniQrApi.Domain.Entities;
using MediatR;

namespace DesafioBackendMiniQrApi.Domain.Handlers
{
    public class ChargeHandler : 
        IRequestHandler<CreateChargeCommand, Charge?>
    {
        public Task<Charge?> Handle(CreateChargeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
