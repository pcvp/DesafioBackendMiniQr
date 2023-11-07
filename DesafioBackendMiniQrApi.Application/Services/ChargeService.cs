using AutoMapper;
using DesafioBackendMiniQrApi.Application.Interfaces;
using DesafioBackendMiniQrApi.Application.ViewModels.Inputs;
using DesafioBackendMiniQrApi.Application.ViewModels.Results;
using DesafioBackendMiniQrApi.Application.ViewModels.Shared;
using DesafioBackendMiniQrApi.CrossCutting.ErrorNotification;
using DesafioBackendMiniQrApi.Domain.Commands;
using DesafioBackendMiniQrApi.Domain.Interfaces;
using MediatR;

namespace DesafioBackendMiniQrApi.Application.Services
{
    public class ChargeService : IChargeService
    {
        private IMapper _mapper;
        private IMediator _mediator;
        private readonly IChargeRepository _chargeRepository;


        public ChargeService(IMapper mapper, IMediator mediator, IChargeRepository chargeRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _chargeRepository = chargeRepository;
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

        public async Task<ResultChargeVm> GetCharge(Guid chargeId)
        {
            var charge = await _chargeRepository.GetByIdAsync(chargeId);
            if (charge is not null) return _mapper.Map<ResultChargeVm>(charge);

            await _mediator.Publish(ErrorNotification.MINIQR0004);
            return null;
        }
    }
}
