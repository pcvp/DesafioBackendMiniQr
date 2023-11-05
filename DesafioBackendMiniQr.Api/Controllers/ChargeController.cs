using DesafioBackendMiniQrApi.Application.Interfaces;
using DesafioBackendMiniQrApi.Application.ViewModels.Inputs;
using DesafioBackendMiniQrApi.Application.ViewModels.Results;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackendMiniQr.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChargeController : ControllerBase
    {
        private IChargeService _chargeService;

        public ChargeController(IChargeService chargeService)
        {
            _chargeService = chargeService;
        }

        [HttpPost]
        public async Task<ResultCreateChargeVm> CreateCharge(
            InputCreateChargeVm createChargeVm
            )
        {
            return await _chargeService.CreateCharge(createChargeVm);
        }
    }
}