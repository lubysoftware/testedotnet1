namespace Luby.API.ViewModel
{
    using System.ComponentModel.DataAnnotations;
    public class ProjetoViewModel
    {
        public int? Id { get; set; }
        
        [Required(ErrorMessage = " O campo Descricao é obrigatório!")]
        [StringLength(255, ErrorMessage = "O campo Descricao deve ter no máximo 255 caracteres!")]
        public string Descricao { get; set; }
    }
}