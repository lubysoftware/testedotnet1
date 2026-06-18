using System;

namespace Hours.Application.DataContract.Request.User
{
    public sealed class UserFilterRequest
    {
        public Guid? Id {get; set;}
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
