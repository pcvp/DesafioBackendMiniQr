using DesafioBackendMiniQrApi.Application.ViewModels.Inputs;
using DesafioBackendMiniQrApi.Application.ViewModels.Results;

namespace DesafioBackendMiniQrApi.Application.Interfaces
{
    public interface IChargeService
    {
        Task<ResultCreateChargeVm> CreateCharge(InputCreateChargeVm createChargeVm);
    }
}
