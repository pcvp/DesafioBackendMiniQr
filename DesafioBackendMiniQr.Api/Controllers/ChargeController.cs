using DesafioBackendMiniQrApi.Application.Interfaces;
using DesafioBackendMiniQrApi.Application.ViewModels.Inputs;
using DesafioBackendMiniQrApi.Application.ViewModels.Results;
using DesafioBackendMiniQrApi.CrossCutting.ErrorNotification;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackendMiniQr.Api.Controllers
{
    [ApiController]
    [Route("{version}/[controller]")]
    public class ChargeController : MyControllerBase
    {
        private IChargeService _chargeService;

        public ChargeController(IErrorNotificationResult errorNotificationResult,
            IChargeService chargeService) : base(errorNotificationResult)
        {
            _chargeService = chargeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCharge(
            CreateChargeInputVm createChargeVm, 
            string version)
        {
            return await RunContent(async () =>
            {
                return await _chargeService.CreateCharge(createChargeVm);
            }, "Cobrança criada com sucesso.");
          
        }

        [HttpPost]
        [Route("cancel")]
        public async Task<IActionResult> CancelCharge(
            CancelChargeInputVm cancelChargeVm,
            string version)
        {
            return await RunContent(async () =>
            {
                return await _chargeService.CancelCharge(cancelChargeVm);
            }, "Cobrança cancelada com sucesso.");

        }

        [HttpGet("{chargeId}")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> CancelCharge(
            [FromRoute] Guid chargeId,
            string version)
        {
            return await RunContent(async () =>
            {
                return await _chargeService.GetCharge(chargeId);
            }, "Cobrança encontrada.");

        }
    }
}