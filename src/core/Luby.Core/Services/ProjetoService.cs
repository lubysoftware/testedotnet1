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
        public ProjetoService(
            IProjetoRepository projetoRepository,
            INotificador notificador
        ) : base (notificador)
        {
            _projetoRepository = projetoRepository;
        }

        public async Task Delete(int id)
        {
            await _projetoRepository.Delete(id);
        }

        public void Dispose()
        {
            _projetoRepository?.Dispose();
        }

        public async Task<Projeto> Save(Projeto entity)
        {
            if(!ExecuteValidation(new ProjetoValidation(), entity)) return null;

            await _projetoRepository.Save(entity);

            return entity;
        }
    }
}