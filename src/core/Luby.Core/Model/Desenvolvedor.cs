namespace Luby.Core.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Entidade de Desenvolvedor
    /// </summary>
    public class Desenvolvedor : Entity
    {
        public Desenvolvedor()
        {
            Projetos = new List<Projeto>();
        }
        public string Nome { get; set; }
        public ICollection<Projeto> Projetos { get; set; }
    }
}