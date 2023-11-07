using DesafioBackendMiniQrApi.Application.ViewModels.Inputs;
using DesafioBackendMiniQrApi.Application.ViewModels.Results;

namespace DesafioBackendMiniQrApi.Application.Interfaces
{
    public interface IUserService
    {
        Task<ResultUserVm> CreateUser(CreateUserInputVm createUserVm);
    }
}
