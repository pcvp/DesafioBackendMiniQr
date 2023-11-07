using DesafioBackendMiniQrApi.Application.Interfaces;
using DesafioBackendMiniQrApi.Application.ViewModels.Inputs;
using DesafioBackendMiniQrApi.Application.ViewModels.Results;
using DesafioBackendMiniQrApi.CrossCutting.ErrorNotification;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackendMiniQr.Api.Controllers
{
    [ApiController]
    [Route("{version}/[controller]")]
    public class UserController : MyControllerBase
    {
        private IUserService _userService;

        public UserController(IErrorNotificationResult errorNotificationResult,
            IUserService userService) : base(errorNotificationResult)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(
            CreateUserInputVm createUserVm, 
            string version)
        {
            return await RunContent(async () =>
            {
                return await _userService.CreateUser(createUserVm);
            }, "Usuário criado com sucesso.");
          
        }
    }
}