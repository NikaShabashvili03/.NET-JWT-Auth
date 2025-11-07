using BCrypt.Net;

namespace DotnetSqlBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";

        private string _passwordHash = "";

        public string Password
        {
            set => _passwordHash = BCrypt.Net.BCrypt.HashPassword(value);
        }

        public string PasswordHash
        {
            get => _passwordHash;
            private set => _passwordHash = value;
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, _passwordHash);
        }
    }
}
