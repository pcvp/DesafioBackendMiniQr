using DesafioBackendMiniQrApi.CrossCutting.Models;

namespace DesafioBackendMiniQrApi.Domain.Entities
{
    public class Charge : Entity
    {
        public ChargeStatus Status { get; private set; }
        public decimal Value { get; private set; }
        public string? QrCode { get; private set; }
        public string? ExternalId { get; private set; }

        public override bool IsValid()
        {
            return true;
        }

        public void SetQrCode(string qrCode)
        {
            QrCode = qrCode;
        }

        public void SetExternalId(string externalId)
        {
            ExternalId = externalId;
        }

        #region Factories
        public class Factory
        {
            public static Charge NewCharge(decimal value)
            {
                return new Charge()
                {
                    Status = ChargeStatus.PENDING,
                    Value = value
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
