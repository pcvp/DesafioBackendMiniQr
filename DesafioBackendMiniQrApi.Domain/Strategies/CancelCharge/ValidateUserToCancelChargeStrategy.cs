using DesafioBackendMiniQrApi.CrossCutting.ErrorNotification;
using DesafioBackendMiniQrApi.CrossCutting.Interfaces;
using DesafioBackendMiniQrApi.CrossCutting.Models;
using DesafioBackendMiniQrApi.Domain.Entities;
using MediatR;

namespace DesafioBackendMiniQrApi.Domain.Strategies.CancelCharge
{
    public class ValidateUserToCancelChargeStrategy : IStrategy
    {
        private readonly IMediator _mediator;

        public ValidateUserToCancelChargeStrategy(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> Process<T>(T entity, T? source) where T : Entity
        {
            switch (entity)
            {
                case Charge charge:
                    return await ValidateUserToCancelCharge(charge);
                default:
                    await _mediator.Publish(ErrorNotification.MINIQR0002);
                    return false;
            }
        }

        private async Task<bool> ValidateUserToCancelCharge(Charge charge)
        {
            if (charge.CancelledByUser is not null && charge.CancelledByUser.Type == UserType.Administrator) return true;

            await _mediator.Publish(ErrorNotification.MINIQR0009);
            return false;
        }
    }
}
