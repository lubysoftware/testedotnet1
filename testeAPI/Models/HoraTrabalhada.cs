using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TesteApi.Models
{
    public class HoraTrabalhada
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int DesenvolvedorId { get; set; }
        
        [ForeignKey("DesenvolvedorId")]
        public Desenvolvedor Desenvolvedor { get; set; }
        public int ProjetoId { get; set; }

        [ForeignKey("ProjetoId")]
        public Projeto Projeto { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
        
    }
}