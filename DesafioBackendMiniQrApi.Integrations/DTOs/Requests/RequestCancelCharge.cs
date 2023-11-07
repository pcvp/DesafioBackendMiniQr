using Newtonsoft.Json;

namespace Pipedream.Integration.DTOs.Requests
{
    public class RequestCancelCharge
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
