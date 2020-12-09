using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models.Validations;

namespace Business.Services
{
    public class LancamentoDeHoraService : BaseService, ILancamentoDeHoraService
    {
        private readonly IDesenvolvedorRepository _desenvolvedorRepository;
        private readonly ILancamentoDeHoraRepository _lancamentoDeHoraRepository;
        private readonly IProjetoRepository _projetoRepository;
        private readonly IUser _user;

        public LancamentoDeHoraService(
            IDesenvolvedorRepository desenvolvedorRepository,
            IProjetoRepository projetoRepository,
            ILancamentoDeHoraRepository lancamentoDeHoraRepository,
            INotificador notificador) : base(notificador)
        {
            _desenvolvedorRepository = desenvolvedorRepository;
            _lancamentoDeHoraRepository = lancamentoDeHoraRepository;
            _projetoRepository = projetoRepository;
            // _user = user;
        }

        public async Task<bool> Adicionar(LancamentoDeHora lancamento)
        {
            //var user = _user.GetUserId();
            if (!ExecutarValidacao(new LancamentoDeHoraValidation(), lancamento)) return false;

            var dev = await _desenvolvedorRepository.ObterPorId(lancamento.Desenvolvedor.Id);
            if (dev == null)
            {
                Notificar("Desenvolvedor não cadastrado.");
                return false;
            }

            var proj = await _projetoRepository.ObterPorId(lancamento.Projeto.Id);
            if (proj == null)
            {
                Notificar("Projeto não cadastrado.");
                return false;
            }

            lancamento.Desenvolvedor = dev;
            lancamento.Projeto = proj;
            await _lancamentoDeHoraRepository.Adicionar(lancamento);
            return true;
        }

        public async Task<bool> Atualizar(LancamentoDeHora lancamento)
        {
            //var user = _user.GetUserId();
            if (!ExecutarValidacao(new LancamentoDeHoraValidation(), lancamento)) return false;

            var dev = await _desenvolvedorRepository.ObterPorId(lancamento.Desenvolvedor.Id);
            if (dev == null)
            {
                Notificar("Desenvolvedor não cadastrado.");
                return false;
            }

            var proj = await _projetoRepository.ObterPorId(lancamento.Projeto.Id);
            if (proj == null)
            {
                Notificar("Projeto não cadastrado.");
                return false;
            }

            await _lancamentoDeHoraRepository.Atualizar(lancamento);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            if (await _lancamentoDeHoraRepository.ObterPorId(id) == null)
            {
                Notificar("Lancamento não cadastrado");
                return false;
            }

            await _lancamentoDeHoraRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _lancamentoDeHoraRepository?.Dispose();
        }
    }
}