using DesafioBackendMiniQrApi.Domain.Entities;
using MediatR;

namespace DesafioBackendMiniQrApi.Domain.Commands
{
    public class CancelChargeCommand : IRequest<Charge?>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
