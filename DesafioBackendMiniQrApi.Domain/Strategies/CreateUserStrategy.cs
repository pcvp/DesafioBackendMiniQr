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
    public class CreateUserStrategy : IStrategy
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public CreateUserStrategy(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }
        public async Task<bool> Process<T>(T entity, T? source) where T : Entity
        {
            switch (entity)
            {
                case User user:
                    return await CreateUser(user);
                default:
                    await _mediator.Publish(ErrorNotification.MINIQR0001);
                    return false;
            }
        }

        private async Task<bool> CreateUser(User user)
        {
            var userExists = (await _userRepository.FindAsNoTrackingAsync(u => u.Email.Equals(user.Email))).FirstOrDefault();
            if (userExists is not null)
            {
                await _mediator.Publish(ErrorNotification.MINIQR0006);
                return false;
            }

            await _userRepository.CreateAsync(user);
            return true;
        }
    }
}
