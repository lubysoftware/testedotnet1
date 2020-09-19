using System;

namespace Business.Models
{
    /// <summary>
    /// Classe abstrata base para os modelos, todos modelos deve herdar esta classe
    /// </summary>
    /// <remarks>
    /// Autor   : Luiz Fernando
    /// Data    : 19/09/2020
    /// </remarks>
    public abstract class Entity
    {
        #region Properties
        public Guid Id { get; set; }
        #endregion Properties

        #region Cosntructor
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        #endregion Constructor
    }
}
