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
        public DateTime Initial { get; set; }
        public DateTime End { get; set; }
        public Guid IdProject { get; set; }
        public Guid IdDeveloper { get; set; }
        #endregion Properties

        #region Relation Entity Framework Core
        public Project Project { get; set; }
        public Developer Developer { get; set; }
        #endregion Relation Entity Framework Core

        public double ProxyHoras
        {
            get
            {
                TimeSpan timeSpan = End - Initial;

                return timeSpan.TotalHours;
            }
        }
    }
}
