using Newtonsoft.Json;

namespace DesafioBackendMiniQrApi.Application.ViewModels.Inputs
{
    public class CancelChargeInputVm
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
