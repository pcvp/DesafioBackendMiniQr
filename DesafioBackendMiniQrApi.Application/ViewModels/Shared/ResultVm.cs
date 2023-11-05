using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace DesafioBackendMiniQrApi.Application.ViewModels.Shared
{
    [ExcludeFromCodeCoverage]
    public class ResultVm<T>
    {
        public ResultVm()
        {

        }

        public ResultVm(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = (T)data;
        }

        [JsonProperty("success")]
        public bool Success { get; private set; } = true;

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        public void Error(string message)
        {
            Success = false;
            Message = message;
        }
    }
}
