using Newtonsoft.Json;

namespace Pipedream.Integration.DTOs.Requests
{
    public class RequestCreateCharge
    {
        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}
