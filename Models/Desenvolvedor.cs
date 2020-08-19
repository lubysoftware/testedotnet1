namespace LancamentoHorasAPI.Models
{
    public class Desenvolvedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Desenvolvedor()
        {
        }

        public Desenvolvedor(string nome)
        {
            Nome = nome;
        }
    }
}