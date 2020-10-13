using System;
using System.ComponentModel.DataAnnotations;

namespace Luby.API.ViewModel
{
    public class LancarHorasViewModel
    {
        [Required(ErrorMessage = "O campo DtIncio é obrigatório!")]
        [DataType(DataType.DateTime)]
        public DateTime DtInicio { get; set; }

        [Required(ErrorMessage = "O campo DtFim é obrigatório!")]
        [DataType(DataType.DateTime)]
        public DateTime DtFim { get; set; }

        [Required(ErrorMessage = "O campo ProjetoId é obrigatório!")]
        public int ProjetoId { get; set; }  

        [Required(ErrorMessage = "O campo DesenvolvedorId é obrigatório!")]
        public int DesenvolvedorId { get; set; }
    }
}