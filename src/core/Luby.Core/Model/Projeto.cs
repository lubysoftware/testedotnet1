namespace Luby.Core.Model
{
    using System;

    /// <summary>
    /// Entidade de Projeto
    /// </summary>
    public class Projeto : Entity
    {
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
    }
}