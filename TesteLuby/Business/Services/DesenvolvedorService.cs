using System;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Validations;

namespace Business.Services
{
    public class DesenvolvedorService : BaseService, IDesenvolvedorService
    {
        private readonly IDesenvolvedorRepository _desenvolvedorRepository;
        private readonly IUser _user;

        public DesenvolvedorService(
            INotificador notificador,
            IDesenvolvedorRepository desenvolvedorRepository) : base(notificador)
        {
            _desenvolvedorRepository = desenvolvedorRepository;
        }

        public async Task<bool> Adicionar(Desenvolvedor desenvolvedor)
        {
            using (_desenvolvedorRepository)
            {
                //var user = _user.GetUserId();
                if (!ExecutarValidacao(new DesenvolvedorValidation(), desenvolvedor))
                    return false;
                if (_desenvolvedorRepository.Buscar(f => f.Email == desenvolvedor.Email).Result.Any())
                {
                    Notificar("Já existe um desenvolvedor com este o email informado.");
                    return false;
                }

                await _desenvolvedorRepository.Adicionar(desenvolvedor);
                return true;
            }
        }

        public async Task<bool> Atualizar(Desenvolvedor desenvolvedor)
        {
            using (_desenvolvedorRepository)
            {
                if (!ExecutarValidacao(new DesenvolvedorValidation(), desenvolvedor)) return false;
                await _desenvolvedorRepository.Atualizar(desenvolvedor);
                return true;
            }
        }

        public async Task<bool> Remover(Guid id)
        {
            using (_desenvolvedorRepository)
            {
                if (await _desenvolvedorRepository.ObterPorId(id) == null)
                {
                    Notificar("Desenvolvedor não cadastrado");
                    return false;
                }

                await _desenvolvedorRepository.Remover(id);
                return true;
            }
        }

        public void Dispose()
        {
            _desenvolvedorRepository?.Dispose();
        }
    }
}