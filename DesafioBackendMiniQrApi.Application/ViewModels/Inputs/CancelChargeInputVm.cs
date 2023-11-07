using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DesafioBackendMiniQrApi.Application.ViewModels.Inputs
{
    public class CancelChargeInputVm
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("user_id")]
        [Required]
        public Guid UserId { get; set; }
    }
}
