namespace DesafioBackendMiniQrApi.CrossCutting.ErrorNotification
{
    public class ErrorNotificationResult : IErrorNotificationResult
    {
        private readonly List<ErrorNotification> _notifications = new List<ErrorNotification>();
        public string? Code { get; set; }
        public int? StatusCode { get; set; }

        public void AddNotification(ErrorNotification notificationErro)
        {
            StatusCode = notificationErro.StatusCode;
            _notifications.Add(notificationErro);
        }

        public List<ErrorNotification> GetNotification()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}
