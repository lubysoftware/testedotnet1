using System;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Validations;

namespace Business.Services
{
    public class ProjetoService : BaseService, IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoService(
            IProjetoRepository projetoRepository,
            INotificador notificador) : base(notificador)
        {
            _projetoRepository = projetoRepository;
        }

        public async Task<bool> Adicionar(Projeto projeto)
        {
            using (_projetoRepository)
            {
                if (!ExecutarValidacao(new ProjetoValidation(), projeto))
                    return false;
                if (_projetoRepository.Buscar(f => f.Nome == projeto.Nome).Result.Any())
                {
                    Notificar("Já existe um projeto com este o nome informado.");
                    return false;
                }

                await _projetoRepository.Adicionar(projeto);
                return true;
            }
        }

        public async Task<bool> Atualizar(Projeto projeto)
        {
            using (_projetoRepository)
            {
                if (!ExecutarValidacao(new ProjetoValidation(), projeto)) return false;
                await _projetoRepository.Atualizar(projeto);
                return true;
            }
        }

        public async Task<bool> Remover(Guid id)
        {
            using (_projetoRepository)
            {
                if (await _projetoRepository.ObterPorId(id) == null)
                {
                    Notificar("Projeto não cadastrado");
                    return false;
                }

                await _projetoRepository.Remover(id);
                return true;
            }
        }

        public void Dispose()
        {
            _projetoRepository?.Dispose();
        }
    }
}