namespace DesafioBackendMiniQrApi.Application.ViewModels.Results
{
    public class ResultChargeVm
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public decimal Value { get; set; }
        public string? QrCode { get; set; }
    }
}
