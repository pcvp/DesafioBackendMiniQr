using Newtonsoft.Json;

namespace Pipedream.Integration.DTOs.Responses
{
    public class ResponseDto<T>
    {
        public ResponseDto(T data)
        {
            Data = data;
            Success = true;
        }

        public ResponseDto(string message)
        {
            Message = message;
            Success = false;
        }

        public bool Success { get; private set; }
        public T? Data { get; set; }
        public string? Message { get; set; }

        
    }
}
