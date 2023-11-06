namespace DesafioBackendMiniQrApi.CrossCutting.Helpers
{
    public class AppSettings
    {
        public Connectionstrings? ConnectionStrings { get; set; }
    }

    public class Connectionstrings
    {
        public string? DbContext { get; set; }
    }
}
