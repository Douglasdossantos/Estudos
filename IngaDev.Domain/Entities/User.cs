using BC = BCrypt.Net.BCrypt;
namespace IngaDev.Domain.Entities
{
    public class User : BaseEntity
    {
        private string _Password { get; set; }
        public string UserName { get; set; }
        public string Password { get => _Password; set => _Password = BC.HashPassword(value); }

        public bool VerifyPassword(string senha) => BC.Verify(senha, _Password);
        
    }
}
