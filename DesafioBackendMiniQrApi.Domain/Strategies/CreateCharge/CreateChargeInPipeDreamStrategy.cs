using DesafioBackendMiniQrApi.CrossCutting.ErrorNotification;
using DesafioBackendMiniQrApi.CrossCutting.Interfaces;
using DesafioBackendMiniQrApi.CrossCutting.Models;
using DesafioBackendMiniQrApi.Domain.Entities;
using MediatR;
using Pipedream.Integration.DTOs.Requests;
using Pipedream.Integration.Interfaces;

namespace DesafioBackendMiniQrApi.Domain.Strategies.CreateCharge
{
    public class CreateChargeInPipeDreamStrategy : IStrategy
    {
        private readonly IChargeService _chargeService;
        private readonly IMediator _mediator;

        public CreateChargeInPipeDreamStrategy(IChargeService chargeService, IMediator mediator)
        {
            _chargeService = chargeService;
            _mediator = mediator;
        }
        public async Task<bool> Process<T>(T entity, T? source) where T : Entity
        {
            switch (entity)
            {
                case Charge charge:
                    return await CreateCharge(charge);
                default:
                    await _mediator.Publish(ErrorNotification.MINIQR0001);
                    return false;
            }
        }

        private async Task<bool> CreateCharge(Charge charge)
        {
            var createdCharge = await _chargeService.CreateCharge(new RequestCreateCharge()
            {
                Value = charge.Value
            });

            if (createdCharge.Data is null || !createdCharge.Success)
            {
                await _mediator.Publish(ErrorNotification.MINIQR0003);
                return false;
            }

            charge.SetQrCode(createdCharge.Data.QrCode);
            charge.SetExternalId(createdCharge.Data.Id);

            return true;
        }
    }
}
