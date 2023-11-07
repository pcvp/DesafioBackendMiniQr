using Newtonsoft.Json;

namespace Pipedream.Integration.DTOs.Responses
{
    public class ResponseCreateCharge
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("qrCode")]
        public string QrCode { get; set; }
    }
}
