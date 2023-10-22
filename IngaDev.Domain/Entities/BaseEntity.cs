namespace IngaDev.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
