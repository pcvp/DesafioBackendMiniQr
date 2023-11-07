using DesafioBackendMiniQrApi.CrossCutting.ErrorNotification;
using DesafioBackendMiniQrApi.CrossCutting.Interfaces;
using DesafioBackendMiniQrApi.Domain.Bases;
using DesafioBackendMiniQrApi.Domain.Commands;
using DesafioBackendMiniQrApi.Domain.Entities;
using DesafioBackendMiniQrApi.Domain.Interfaces;
using DesafioBackendMiniQrApi.Domain.Strategies;
using MediatR;

namespace DesafioBackendMiniQrApi.Domain.Handlers
{
    public class ChargeHandler : 
        CommandHandler,
        IRequestHandler<CreateChargeCommand, Charge?>,
        IRequestHandler<CancelChargeCommand, Charge?>
    {
        private readonly IChargeRepository _chargeRepository;
        private readonly IMediator _mediator;

        public ChargeHandler(IUnitOfWork uol,
            IMediator mediator,
            IErrorNotificationResult errorNotificationResult, 
            IServiceProvider serviceProvider,
            IChargeRepository chargeRepository) : base(uol, mediator, errorNotificationResult, serviceProvider)
        {
            _chargeRepository = chargeRepository;
            _mediator = mediator;
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
                CreateInstance<CreateChargeInPipeDreamStrategy>(),
                CreateInstance<CreateChargeStrategy>()
            };

            return await RunStrategies(strategies, charge, chargeSource);
        }

        public async Task<Charge?> Handle(CancelChargeCommand request, CancellationToken cancellationToken)
        {
            var charge = await _chargeRepository.GetByIdAsync(request.Id);
            if(charge == null)
            {
                await _mediator.Publish(ErrorNotification.MINIQR0004);
                return null;
            }

            if (!await CancelCharge(charge) || !ValidateEntity(charge))
                return null;

            await Commit(cancellationToken);

            return charge;
        }

        private async Task<bool> CancelCharge(Charge charge, Charge? chargeSource = null)
        {
            var strategies = new List<IStrategy>() {
                CreateInstance<CancelChargeInPipeDreamStrategy>(),
            };

            return await RunStrategies(strategies, charge, chargeSource);
        }
    }
}
