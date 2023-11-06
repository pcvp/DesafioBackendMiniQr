using DesafioBackendMiniQrApi.CrossCutting.ErrorNotification;
using DesafioBackendMiniQrApi.CrossCutting.Interfaces;
using DesafioBackendMiniQrApi.Domain.Bases;
using DesafioBackendMiniQrApi.Domain.Commands;
using DesafioBackendMiniQrApi.Domain.Entities;
using DesafioBackendMiniQrApi.Domain.Strategies;
using MediatR;

namespace DesafioBackendMiniQrApi.Domain.Handlers
{
    public class ChargeHandler : 
        CommandHandler,
        IRequestHandler<CreateChargeCommand, Charge?>
    {
        public ChargeHandler(IUnitOfWork uol,
            IMediator mediator,
            IErrorNotificationResult errorNotificationResult, 
            IServiceProvider serviceProvider) : base(uol, mediator, errorNotificationResult, serviceProvider)
        {
        }

        public async Task<Charge?> Handle(CreateChargeCommand request, CancellationToken cancellationToken)
        {
            var charge = Charge.Factory.NewCharge(request.Value);

            if (!await CreateCharge(charge) || !ValidateEntity(charge))
                return null;

            await Commit(cancellationToken);
            
            return charge;
        }

        private async Task<bool> CreateCharge(Charge charge, Charge? chargeSource = null)
        {
            var strategies = new List<IStrategy>() {
                CreateInstance<CreateChargeStrategy>()
            };

            return await RunStrategies(strategies, charge, chargeSource);
        }
    }
}
