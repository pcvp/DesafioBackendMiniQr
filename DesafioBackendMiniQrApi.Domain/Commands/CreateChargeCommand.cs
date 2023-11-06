using DesafioBackendMiniQrApi.Domain.Entities;
using MediatR;

namespace DesafioBackendMiniQrApi.Domain.Commands
{
    public class CreateChargeCommand : IRequest<Charge?>
    {
    }
}
