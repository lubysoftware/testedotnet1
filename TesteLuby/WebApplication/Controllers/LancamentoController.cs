using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LancamentoController : MainController
    {
        private readonly ILancamentoDeHoraRepository _lancamentoDeHoraRepository;
        private readonly ILancamentoDeHoraService _lancamentoDeHoraService;


        public LancamentoController(
            INotificador notificador,
            ILancamentoDeHoraRepository lancamentoDeHoraRepository,
            IMapper mapper,
            ILancamentoDeHoraService lancamentoDeHoraService) : base(notificador)
        {
            _lancamentoDeHoraRepository = lancamentoDeHoraRepository;
            _mapper = mapper;
            _lancamentoDeHoraService = lancamentoDeHoraService;
        }

        private IMapper _mapper { get; }
        
        
        [HttpGet]
        public async Task<IEnumerable<object>> ObterTodos([FromQuery] bool rank = false)
        {
            if (rank)
            {
                var l = await _lancamentoDeHoraRepository.ObterRank();
                var model = _mapper.Map<IEnumerable<RankingViewModel>>(l);
            
                return model;
            }
            else
            {
                var l = await _lancamentoDeHoraRepository.ObterTodos();
                var model = _mapper.Map<IEnumerable<LancamentoDeHoraViewModel>>(l);

                return model;   
            }
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<DesenvolvedorViewModel>>> ObterPorId(Guid id)
        {
            var l = await _lancamentoDeHoraRepository.ObterPorId(id);
            if (l == null) return NotFound();
            var model = _mapper.Map<LancamentoDeHoraViewModel>(l);

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<LancamentoDeHoraViewModel>> Adicionar(LancamentoDeHoraViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (DateTime.Compare(viewModel.HoraInicio, viewModel.HoraFim) >= 0)
            {
                NotificarErro("Hora Inicio não pode ser maior ou igual a hora fim");
                return CustomResponse();
            }

            var l = _mapper.Map<LancamentoDeHora>(viewModel);
            await _lancamentoDeHoraService.Adicionar(l);
            return CustomResponse();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<LancamentoDeHoraViewModel>> Atualizar(Guid id,
            LancamentoDeHoraViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(viewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (DateTime.Compare(viewModel.HoraInicio, viewModel.HoraFim) >= 0)
            {
                NotificarErro("Hora Inicio não pode ser maior ou igual a hora fim");
                return CustomResponse();
            }

            var l = _mapper.Map<LancamentoDeHora>(viewModel);
            await _lancamentoDeHoraService.Atualizar(_mapper.Map<LancamentoDeHora>(l));

            return CustomResponse(viewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<LancamentoDeHoraViewModel>> Remover(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _lancamentoDeHoraService.Remover(id);

            return CustomResponse();
        }
    }
}