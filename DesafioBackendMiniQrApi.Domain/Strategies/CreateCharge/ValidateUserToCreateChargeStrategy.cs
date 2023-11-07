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

namespace DesafioBackendMiniQrApi.Domain.Strategies.CreateCharge
{
    public class ValidateUserToCreateChargeStrategy : IStrategy
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public ValidateUserToCreateChargeStrategy(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public async Task<bool> Process<T>(T entity, T? source) where T : Entity
        {
            switch (entity)
            {
                case Charge charge:
                    return await ValidateUserToCreateCharge(charge);
                default:
                    await _mediator.Publish(ErrorNotification.MINIQR0002);
                    return false;
            }
        }

        private async Task<bool> ValidateUserToCreateCharge(Charge charge)
        {
            if (charge.User.Type == UserType.Store) return true;

            await _mediator.Publish(ErrorNotification.MINIQR0008);
            return false;
        }
    }
}
