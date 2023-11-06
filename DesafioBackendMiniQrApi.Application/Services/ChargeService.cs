using AutoMapper;
using DesafioBackendMiniQrApi.Application.Interfaces;
using DesafioBackendMiniQrApi.Application.ViewModels.Inputs;
using DesafioBackendMiniQrApi.Application.ViewModels.Results;
using DesafioBackendMiniQrApi.Domain.Commands;
using MediatR;

namespace DesafioBackendMiniQrApi.Application.Services
{
    public class ChargeService : IChargeService
    {
        private IMapper _mapper;
        private IMediator _mediator;

        public ChargeService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultCreateChargeVm> CreateCharge(CreateChargeInputVm createChargeVm)
        {
            var command = _mapper.Map<CreateChargeCommand>(createChargeVm);

            var result = await _mediator.Send(command);

            return _mapper.Map<ResultCreateChargeVm>(result);
        }
    }
}
