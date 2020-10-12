namespace Luby.Core.Model
{
    public class ProjetoDesenvolvedores
    {
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }

        public int DesenvolvedorId { get; set; }
        public Desenvolvedor Desenvolvedor { get; set; }
    }
}