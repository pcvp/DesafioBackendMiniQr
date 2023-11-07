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

        public async Task<ResultChargeVm> CreateCharge(CreateChargeInputVm createChargeVm)
        {
            var command = _mapper.Map<CreateChargeCommand>(createChargeVm);

            var result = await _mediator.Send(command);

            return _mapper.Map<ResultChargeVm>(result);
        }

        public async Task<ResultChargeVm> CancelCharge(CancelChargeInputVm cancelChargeVm)
        {
            var command = _mapper.Map<CancelChargeCommand>(cancelChargeVm);

            var result = await _mediator.Send(command);

            return _mapper.Map<ResultChargeVm>(result);
        }
    }
}
