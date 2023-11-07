using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DesafioBackendMiniQrApi.Application.ViewModels.Inputs
{
    public class CreateChargeInputVm
    {
        [JsonProperty("value")]
        [Required]
        public decimal Value { get; set; }

        [JsonProperty("user_id")]
        [Required]
        public Guid UserId { get; set; }
    }
}
