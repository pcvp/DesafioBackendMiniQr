using MediatR;

namespace DesafioBackendMiniQrApi.CrossCutting.ErrorNotification
{
    public class ErrorNotification : INotification
    {
        public Guid ErrorNotificationId { get; private set; }
        public string Code { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public string? Json { get; private set; }
        public int? StatusCode { get; set; }
        public int? Severity { get; set; }

        /// <summary>
        /// Contrutor 
        /// </summary>
        /// <param name="code">Código de erro do serviço Pix</param>
        /// <param name="key">Nome do parâmetro que o erro está se referindo</param>
        /// <param name="value">Descrição do erro</param>
        /// <param name="statusCode">Default = 400</param>
        /// <param name="severity">Nível de gravidade</param>
        public ErrorNotification(string code, string key, string value, int? statusCode = null, int? severity = null)
        {
            ErrorNotificationId = Guid.NewGuid();
            Key = key;
            Value = value;
            Code = code;
            StatusCode = statusCode;
            Severity = severity;
        }

        public void SetJson(string json) => Json = json;


        /// <summary>
        /// Versão inválida da Api.
        /// </summary>
        public static ErrorNotification MINIQR0001 => new("MINIQR0001", string.Empty, "Versão inválida da Api.", severity: 2);

        /// <summary>
        /// Strategy não implementada para o objeto enviado.
        /// </summary>
        public static ErrorNotification MINIQR0002 => new("MINIQR0002", string.Empty, "Strategy não implementada para o objeto enviado.", severity: 2);

        /// <summary>
        /// Erro ao criar cobrança no parceiro
        /// </summary>
        public static ErrorNotification MINIQR0003 => new("MINIQR0003", string.Empty, "Erro ao criar cobrança no parceiro", severity: 2);

        /// <summary>
        /// Cobrança não encontrada
        /// </summary>
        public static ErrorNotification MINIQR0004 => new("MINIQR0004", string.Empty, "Cobrança não encontrada", severity: 2);


        /// <summary>
        /// Erro ao cancelar cobrança no parceiro
        /// </summary>
        public static ErrorNotification MINIQR0005 => new("MINIQR0005", string.Empty, "Erro ao cancelar cobrança no parceiro", severity: 2);
    }
}