using AutoMapper;
using DesafioBackendMiniQrApi.Application.Interfaces;
using DesafioBackendMiniQrApi.Application.ViewModels.Inputs;
using DesafioBackendMiniQrApi.Application.ViewModels.Results;
using DesafioBackendMiniQrApi.Domain.Commands;
using MediatR;

namespace DesafioBackendMiniQrApi.Application.Services
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private IMediator _mediator;

        public UserService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultUserVm> CreateUser(CreateUserInputVm createUserVm)
        {
            var command = _mapper.Map<CreateUserCommand>(createUserVm);

            var result = await _mediator.Send(command);

            return _mapper.Map<ResultUserVm>(result);
        }
    }
}
