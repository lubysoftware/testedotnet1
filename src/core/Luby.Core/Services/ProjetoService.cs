namespace Luby.Core.Services
{
    using System.Threading.Tasks;
    using Luby.Core.Interfaces.Repositories;
    using Luby.Core.Interfaces.Services;
    using Luby.Core.Model;
    using Luby.Core.Model.Validations;
    using Luby.Core.Notificacoes;

    public class ProjetoService : BaseService, IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IDesenvolvedorRepository _desenvolvedorRepository;
        public ProjetoService(
            IDesenvolvedorRepository desenvolvedorRepository,
            IProjetoRepository projetoRepository,
            INotificador notificador
        ) : base (notificador)
        {
            _projetoRepository = projetoRepository;
            _desenvolvedorRepository = desenvolvedorRepository;
        }

        public async Task<Projeto> Add(Projeto entity)
        {
            if(!ExecuteValidation(new ProjetoValidation(), entity)) return null;

            await _projetoRepository.Add(entity);

            return entity;
        }

        public async Task Delete(int id)
        {
            await _projetoRepository.Delete(id);
        }

        public void Dispose()
        {
            _projetoRepository?.Dispose();
        }

        public async Task Lancar(ProjetoDesenvolvedores projetoDesenvolvedores)
        {
            if(!ExecuteValidation(new ProjetoDesenvolvedoresValidation(), projetoDesenvolvedores)) return;

            var projeto = await _projetoRepository.GetbyId(projetoDesenvolvedores.ProjetoId);

            if(projeto == null) 
            {
                Notify("Não foi encontrado Projeto com o Id informado!");

                return;
            }

            var dev = await _desenvolvedorRepository.GetbyId(projetoDesenvolvedores.DesenvolvedorId);

            if(dev == null)
            {
                Notify("Não foi encontrado Desenvolvedor com o Id informado!");

                return;
            }

            await _projetoRepository.LancarHoras(projetoDesenvolvedores);
        }

        public async Task<Projeto> Update(Projeto entity)
        {
            if(!ExecuteValidation(new ProjetoValidation(), entity)) return null;

            var projeto = await _projetoRepository.GetbyId(entity.Id);

            if(projeto == null)
            {
                Notify("Não foi encontrado Projeto com o Id informado!");

                return null;
            }

            await _projetoRepository.Update(entity);

            return entity;
        }
    }
}