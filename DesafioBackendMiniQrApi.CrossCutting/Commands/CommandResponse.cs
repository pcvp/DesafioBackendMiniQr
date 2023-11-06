namespace DesafioBackendMiniQrApi.CrossCutting.Commands
{
    public class CommandResponse
    {
        public static CommandResponse Ok { get; } = new CommandResponse() { Success = true };
        public static CommandResponse Fail { get; } = new CommandResponse() { Success = false };

        public CommandResponse(bool success = false)
        {
            Success = success;
        }

        public bool Success { get; private set; }
    }
}
