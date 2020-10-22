using System;

namespace LubySoftware.Domain.Models
{
    public class JwtTokenModel
    {
        public bool Authenticated { get; set; }
        public string AccessToken { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
