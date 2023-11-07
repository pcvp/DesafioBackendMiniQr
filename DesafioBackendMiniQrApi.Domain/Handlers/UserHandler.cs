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
    public class UserHandler : 
        CommandHandler,
        IRequestHandler<CreateUserCommand, User?>
    {
        private readonly IMediator _mediator;

        public UserHandler(IUnitOfWork uol,
            IMediator mediator,
            IErrorNotificationResult errorNotificationResult, 
            IServiceProvider serviceProvider,
            IChargeRepository chargeRepository) : base(uol, mediator, errorNotificationResult, serviceProvider)
        {
            _mediator = mediator;
        }

        public async Task<User?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.Factory.NewUser(request.Name, request.Email, request.Type);

            if (!await CreateUser(user) || !ValidateEntity(user))
                return null;

            await Commit(cancellationToken);
            
            return user;
        }

        private async Task<bool> CreateUser(User user, User? userSource = null)
        {
            var strategies = new List<IStrategy>() {
                CreateInstance<CreateUserStrategy>()
            };

            return await RunStrategies(strategies, user, userSource);
        }
    }
}
