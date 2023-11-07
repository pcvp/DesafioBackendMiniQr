using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace DesafioBackendMiniQrApi.Application.ViewModels.Shared
{
    [ExcludeFromCodeCoverage]
    public class ErrorVm
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("json")]
        public string Json { get; set; }

        public ErrorVm(string code, string language, string description, string json)
        {
            Code = code;
            Language = language;
            Description = description;
            Json = json;
        }
    }
}
