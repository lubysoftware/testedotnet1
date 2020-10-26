using System;

namespace Hours.Application.DataContract.Request.User
{
    public sealed class UserRequest
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
