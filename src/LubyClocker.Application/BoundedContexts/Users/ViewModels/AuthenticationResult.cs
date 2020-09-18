using System;

namespace LubyClocker.Application.BoundedContexts.Users.ViewModels
{
    public class AuthenticationResult
    {
        public string AccessToken { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}