using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gerenciador_de_horas_de_desenvolvedores.ContextDB
{
    [Table("Desenvolvedor")]
    public class DesenvolvedorTable : ITable
    {
        [Key]
        public int Id {get; set;}
        
        [Required]
        [Column("Nome desenvolvedor")]
        [MaxLength(120)]
        public string Nome {get; set;}
        
        [Required]
        [Column("Cargo")]
        [MaxLength(50)]
        public string Cargo {get; set;}
        
        [Required]
        [Column("Valor por hora")]
        public double ValorH {get; set;}
    }
}