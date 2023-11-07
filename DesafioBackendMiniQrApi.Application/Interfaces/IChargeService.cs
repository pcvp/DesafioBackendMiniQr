using DesafioBackendMiniQrApi.Application.ViewModels.Inputs;
using DesafioBackendMiniQrApi.Application.ViewModels.Results;

namespace DesafioBackendMiniQrApi.Application.Interfaces
{
    public interface IChargeService
    {
        Task<ResultChargeVm> CreateCharge(CreateChargeInputVm createChargeVm);
        Task<ResultChargeVm> CancelCharge(CancelChargeInputVm cancelChargeVm);
        Task<ResultChargeVm> GetCharge(Guid chargeId);
    }
}
