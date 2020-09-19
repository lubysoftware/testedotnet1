using System;
using System.Collections.Generic;

namespace Business.Models
{
    /// <summary>
    /// Classe de modelo do projeto
    /// </summary>
    /// <remarks>
    /// Autor   : Luiz Fernando
    /// Data    : 19/09/2020
    /// </remarks>
    public class Project : Entity
    {
        #region Properties
        public string Name { get; set; }
        public bool Concluded { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        #endregion Properties

        #region Relational Entity Framework Core
        public IEnumerable<LaunchTime> LaunchTimes { get; set; }
        #endregion Relational Entity Framework Core
    }
}
