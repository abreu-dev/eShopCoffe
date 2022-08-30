namespace Framework.Core.Data.Entities
{
    public abstract class EntityData
    {
        public const string DefaultUser = "System";

        public Guid Id { get; set; }

        public DateTime CreatedDate { get; private set; }
        public string CreatedBy { get; private set; }

        public DateTime? UpdatedDate { get; private set; }
        public string? UpdatedBy { get; private set; }

        protected EntityData()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            CreatedBy = DefaultUser;
        }

        public void OnCreate(DateTime createdDate, string createdBy)
        {
            CreatedDate = createdDate;
            CreatedBy = createdBy;
        }

        public void OnUpdate(DateTime updatedDate, string updatedBy)
        {
            UpdatedDate = updatedDate;
            UpdatedBy = updatedBy;
        }
    }
}
