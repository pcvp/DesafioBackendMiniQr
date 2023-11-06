namespace DesafioBackendMiniQrApi.CrossCutting.ErrorNotification
{
    public interface IErrorNotificationResult
    {
        int? StatusCode { get; set; }
        void AddNotification(ErrorNotification notificationErro);
        bool HasNotification();
        List<ErrorNotification> GetNotification();
    }
}
