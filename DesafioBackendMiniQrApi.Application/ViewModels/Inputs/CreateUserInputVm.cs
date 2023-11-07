using DesafioBackendMiniQrApi.Domain.Entities;
using Newtonsoft.Json;

namespace DesafioBackendMiniQrApi.Application.ViewModels.Inputs
{
    public class CreateUserInputVm
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("type")]
        public UserType Type { get; set; }
    }
}
