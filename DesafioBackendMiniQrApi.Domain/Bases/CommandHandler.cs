using DesafioBackendMiniQrApi.CrossCutting.ErrorNotification;
using DesafioBackendMiniQrApi.CrossCutting.Interfaces;
using DesafioBackendMiniQrApi.CrossCutting.Models;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioBackendMiniQrApi.Domain.Bases
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediator _mediator;
        private readonly IErrorNotificationResult _errorNotificationResult;
        private readonly IServiceProvider _serviceProvider;

        protected CommandHandler(IUnitOfWork uol,
                                 IMediator mediator,
                                 IErrorNotificationResult errorNotificationResult,
                                 IServiceProvider serviceProvider)
        {
            _uow = uol;
            _mediator = mediator;
            _errorNotificationResult = errorNotificationResult;
            _serviceProvider = serviceProvider;
        }

        protected async Task<bool> Commit(CancellationToken cancellationToken = default)
        {
            if (_errorNotificationResult.HasNotification())
                return false;

            var commandResponse = await _uow.Commit(cancellationToken);
            return commandResponse.Success;
        }

        protected bool ValidateEntity<T>(T entity) where T : Entity
        {
            return entity.IsValid();
        }

        protected IStrategy CreateInstance<T>() where T : IStrategy
        {
            return (IStrategy)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(T));
        }

        protected async Task<bool> RunStrategies<T>(IList<IStrategy> strategies, T entity, T? source) where T : Entity
        {
            foreach (var strategy in strategies)
            {
                if (!await strategy.Process(entity, source))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
