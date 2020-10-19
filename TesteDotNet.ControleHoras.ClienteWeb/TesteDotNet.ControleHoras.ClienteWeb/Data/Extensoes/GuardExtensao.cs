using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteDotNet.ControleHoras.ClienteWeb.Data.Extensoes
{
    public static class GuardExtensao
    {
        public static void CheckArgumentIsNull(this object o, string name)
        {
            if (o == null)
                throw new ArgumentNullException(name);
        }
    }
}
