using Newtonsoft.Json;

namespace DesafioBackendMiniQrApi.Application.ViewModels.Inputs
{
    public class CreateChargeInputVm
    {
        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}
