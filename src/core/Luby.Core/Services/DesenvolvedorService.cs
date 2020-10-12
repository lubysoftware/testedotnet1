namespace Luby.Core.Services
{
    using System.Threading.Tasks;
    using Luby.Core.Interfaces.Repositories;
    using Luby.Core.Interfaces.Services;
    using Luby.Core.Model;
    using Luby.Core.Model.Validations;
    using Luby.Core.Notificacoes;

    public class DesenvolvedorService : BaseService, IDesenvolvedorService
    {
        private readonly IDesenvolvedorRepository _desenvolvedorRepository;
        public DesenvolvedorService(
            IDesenvolvedorRepository desenvolvedorRepository,
            INotificador notificador
        ) : base(notificador)
        {
            _desenvolvedorRepository = desenvolvedorRepository;    
        }

        public async Task Delete(int id)
        {
            await _desenvolvedorRepository.Delete(id);
        }

        public void Dispose()
        {
            _desenvolvedorRepository?.Dispose();
        }

        public async Task<Desenvolvedor> Save(Desenvolvedor entity)
        {
            if(!ExecuteValidation(new DesenvolvedorValidation(), entity)) return null;

            await _desenvolvedorRepository.Save(entity);

            return entity;
        }
    }
}