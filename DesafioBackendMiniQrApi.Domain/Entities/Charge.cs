using DesafioBackendMiniQrApi.CrossCutting.Models;

namespace DesafioBackendMiniQrApi.Domain.Entities
{
    public class Charge : Entity
    {
        public ChargeStatus Status { get; private set; }
        public decimal Value { get; private set; }
        public string? QrCode { get; private set; }
        public string? ExternalId { get; private set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public virtual User? CancelledByUser { get; set; }
        public Guid? CancelledByUserId { get; set; }
        public override bool IsValid()
        {
            return true;
        }

        public void SetQrCode(string qrCode)
        {
            QrCode = qrCode;
        }

        public void SetStatus(ChargeStatus status)
        {
            Status = status;
        }

        public void SetExternalId(string externalId)
        {
            ExternalId = externalId;
        }

        #region Factories
        public class Factory
        {
            public static Charge NewCharge(decimal value, User user)
            {
                return new Charge()
                {
                    Status = ChargeStatus.PENDING,
                    Value = value,
                    User = user
                };
            }
        }
        #endregion
    }

    public enum ChargeStatus
    {
        PENDING,
        PAID,
        CANCELED
    }
}
