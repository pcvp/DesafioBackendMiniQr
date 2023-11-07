using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace DesafioBackendMiniQrApi.Application.ViewModels.Shared
{
    [ExcludeFromCodeCoverage]
    public class ErrorResultVm
    {
        [JsonProperty("success")]
        public bool Success { get; } = false;

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("errors")]
        public IList<ErrorVm> Errors { get; set; } = new List<ErrorVm>();
    }
}
