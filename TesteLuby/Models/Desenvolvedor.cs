using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteLuby.Generics;

namespace TesteLuby.Models
{
    public class Desenvolvedor : Entity<int>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
