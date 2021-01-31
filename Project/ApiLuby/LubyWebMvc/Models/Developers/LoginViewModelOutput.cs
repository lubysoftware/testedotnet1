using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubyWebMvc.Models.Developers
{
    public class LoginViewModelOutput
    {
        public string Token { get; set; }
        public LoginViewModelDetailsOutput Developer { get; set; }

    }
    public class LoginViewModelDetailsOutput
    {
        public int Codigo { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}


