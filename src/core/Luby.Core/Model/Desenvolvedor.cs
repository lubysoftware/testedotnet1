namespace Luby.Core.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Entidade de Desenvolvedor
    /// </summary>
    public class Desenvolvedor : Entity
    {
        public string Nome { get; set; }
        
        public IList<ProjetoDesenvolvedores> ProjetoDesenvolvedor { get; set; }
    }
}