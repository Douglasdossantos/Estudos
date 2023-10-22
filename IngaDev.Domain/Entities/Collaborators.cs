namespace IngaDev.Domain.Entities
{
    public class Collaborators : BaseEntity
    {
        public string Name { get; set; }
        public User User { get; set; }
    }
}
