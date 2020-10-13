namespace Luby.Core.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Entidade de Projeto
    /// </summary>
    public class Projeto : Entity
    {
        public string Descricao { get; set; }
        public IList<ProjetoDesenvolvedores> ProjetoDesenvolvedor { get; set; }
    }
}