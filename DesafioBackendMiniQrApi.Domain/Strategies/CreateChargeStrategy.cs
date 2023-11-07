using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioBackendMiniQrApi.CrossCutting.ErrorNotification;
using DesafioBackendMiniQrApi.CrossCutting.Interfaces;
using DesafioBackendMiniQrApi.CrossCutting.Models;
using DesafioBackendMiniQrApi.Domain.Entities;
using DesafioBackendMiniQrApi.Domain.Interfaces;
using MediatR;

namespace DesafioBackendMiniQrApi.Domain.Strategies
{
    public class CreateChargeStrategy : IStrategy
    {
        private readonly IChargeRepository _chargeRepository;
        private readonly IMediator _mediator;

        public CreateChargeStrategy(IChargeRepository chargeRepository, IMediator mediator)
        {
            _chargeRepository = chargeRepository;
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
            await _chargeRepository.CreateAsync(charge);
            return true;
        }
    }
}
