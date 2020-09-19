using System;

namespace Business.Models
{
    /// <summary>
    /// Classe modelo para o lançamento de horas
    /// </summary>
    public class LaunchTime : Entity
    {
        #region Properties
        public DateTime RegisterDate { get; set; }
        public int HoraAmount { get; set; }
        #endregion Properties

        #region Relation Entity Framework Core
        public Developer Developer { get; set; }
        public Project Project { get; set; }
        #endregion Relation Entity Framework Core
    }
}
