using MediatR;

namespace DesafioBackendMiniQrApi.CrossCutting.ErrorNotification
{
    public class ErrorNotificationHandler : INotificationHandler<ErrorNotification>
    {
        private readonly IErrorNotificationResult _notificationErroResultado;

        public ErrorNotificationHandler(IErrorNotificationResult notificationErroResultado)
            => _notificationErroResultado = notificationErroResultado;

        public async Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
            => await Task.Run(() => _notificationErroResultado.AddNotification(notification));
    }
}