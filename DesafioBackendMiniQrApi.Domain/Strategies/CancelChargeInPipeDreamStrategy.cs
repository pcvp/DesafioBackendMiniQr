using DesafioBackendMiniQrApi.CrossCutting.ErrorNotification;
using DesafioBackendMiniQrApi.CrossCutting.Interfaces;
using DesafioBackendMiniQrApi.CrossCutting.Models;
using DesafioBackendMiniQrApi.Domain.Entities;
using MediatR;
using Pipedream.Integration.DTOs.Requests;
using Pipedream.Integration.Interfaces;

namespace DesafioBackendMiniQrApi.Domain.Strategies
{
    public class CancelChargeInPipeDreamStrategy : IStrategy
    {
        private readonly IChargeService _chargeService;
        private readonly IMediator _mediator;

        public CancelChargeInPipeDreamStrategy(IChargeService chargeService, IMediator mediator)
        {
            _chargeService = chargeService;
            _mediator = mediator;
        }
        public async Task<bool> Process<T>(T entity, T? source) where T : Entity
        {
            switch (entity)
            {
                case Charge charge:
                    return await CancelCharge(charge);
                default:
                    await _mediator.Publish(ErrorNotification.MINIQR0001);
                    return false;
            }
        }

        private async Task<bool> CancelCharge(Charge charge)
        {
            var cancelledCharge = await _chargeService.CancelCharge(new RequestCancelCharge()
            {
                Id = charge.ExternalId!
            });

            if (cancelledCharge.Data is null || !cancelledCharge.Success){
                await _mediator.Publish(ErrorNotification.MINIQR0005);
                return false;
            }

            if(cancelledCharge.Data.Status.Equals("Canceled"))
                charge.SetStatus(ChargeStatus.CANCELED);
            
            return true;
        }
    }
}
