using System;

namespace Hours.Application.DataContract.Request.User
{
    public sealed class UserGeneralRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
