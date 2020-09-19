namespace Business.Models
{
    /// <summary>
    /// Classe de modelo do desenvolvedor
    /// </summary>
    /// <remarks>
    /// Autor   : Luiz Fernando
    /// Data    : 19/09/2020
    /// </remarks>
    public class Developer : Entity
    {
        #region Properties
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Uf { get; set; }
        #endregion Properties
    }
}
