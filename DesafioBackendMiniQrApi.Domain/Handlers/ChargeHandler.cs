using DesafioBackendMiniQrApi.CrossCutting.ErrorNotification;
using DesafioBackendMiniQrApi.CrossCutting.Interfaces;
using DesafioBackendMiniQrApi.Domain.Bases;
using DesafioBackendMiniQrApi.Domain.Commands;
using DesafioBackendMiniQrApi.Domain.Entities;
using DesafioBackendMiniQrApi.Domain.Interfaces;
using DesafioBackendMiniQrApi.Domain.Strategies.CancelCharge;
using DesafioBackendMiniQrApi.Domain.Strategies.CreateCharge;
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
        private readonly IUserRepository _userRepository;

        public ChargeHandler(IUnitOfWork uol,
            IMediator mediator,
            IErrorNotificationResult errorNotificationResult, 
            IServiceProvider serviceProvider,
            IChargeRepository chargeRepository,
            IUserRepository userRepository) : base(uol, mediator, errorNotificationResult, serviceProvider)
        {
            _chargeRepository = chargeRepository;
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public async Task<Charge?> Handle(CreateChargeCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user is null)
            {
                await _mediator.Publish(ErrorNotification.MINIQR0007, cancellationToken);
                return null;
            }
            var charge = Charge.Factory.NewCharge(request.Value, user);

            if (!await CreateCharge(charge) || !ValidateEntity(charge))
                return null;

            await Commit(cancellationToken);
            
            return charge;
        }

        private async Task<bool> CreateCharge(Charge charge, Charge? chargeSource = null)
        {
            var strategies = new List<IStrategy>() {
                CreateInstance<ValidateUserToCreateChargeStrategy>(),
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
                await _mediator.Publish(ErrorNotification.MINIQR0004, cancellationToken);
                return null;
            }

            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user is null)
            {
                await _mediator.Publish(ErrorNotification.MINIQR0007, cancellationToken);
                return null;
            }

            charge.CancelledByUser = user;

            if (!await CancelCharge(charge) || !ValidateEntity(charge))
                return null;

            await Commit(cancellationToken);

            return charge;
        }

        private async Task<bool> CancelCharge(Charge charge, Charge? chargeSource = null)
        {
            var strategies = new List<IStrategy>() {
                CreateInstance<ValidateUserToCancelChargeStrategy>(),
                CreateInstance<CancelChargeInPipeDreamStrategy>(),
            };

            return await RunStrategies(strategies, charge, chargeSource);
        }
    }
}
