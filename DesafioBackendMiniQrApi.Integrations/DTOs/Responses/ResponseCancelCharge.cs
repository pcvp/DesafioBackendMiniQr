using Newtonsoft.Json;

namespace Pipedream.Integration.DTOs.Responses
{
    public class ResponseCancelCharge
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
