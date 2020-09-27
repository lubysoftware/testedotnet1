using testedotnet1.Entities;

namespace testedotnet1.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; private set; }
        public string UserName { get; private set; }
        public string Role { get; private set; }
        public string Token { get; private set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            UserName = user.UserName;
            Role = user.Role;
            Token = token;
        }
    }
}