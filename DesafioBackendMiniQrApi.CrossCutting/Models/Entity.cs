using FluentValidation.Results;

namespace DesafioBackendMiniQrApi.CrossCutting.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            //ValidationResult = new ValidationResult();
        }
        public Guid Id { get; protected set; }

        public DateTime CreatedAtUtc { get; protected set; }

        public DateTime? UpdatedAtUtc { get; protected set; }

        public abstract bool IsValid();

        //public virtual ValidationResult ValidationResult { get; protected set; }        

        public void GenerateId(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }

        public void SetCreatedAtUtc(DateTime dateTime)
        {
            CreatedAtUtc = dateTime;
        }

        public bool IsTracked()
        {
            return CreatedAtUtc > DateTime.MinValue;
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + "[Id = " + Id + " ]";
        }
    }
}
