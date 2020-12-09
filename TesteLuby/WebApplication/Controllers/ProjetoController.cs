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
    public class ProjetoController : MainController
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IProjetoService _projetoService;


        public ProjetoController(
            INotificador notificador,
            IProjetoRepository projetoRepository,
            IMapper mapper,
            IProjetoService projetoService) : base(notificador)
        {
            _projetoRepository = projetoRepository;
            _mapper = mapper;
            _projetoService = projetoService;
        }

        private IMapper _mapper { get; }

        [HttpGet]
        public async Task<IEnumerable<ProjetoViewModel>> ObterTodos()
        {
            var dev = await _projetoRepository.ObterTodos();
            var model = _mapper.Map<IEnumerable<ProjetoViewModel>>(dev);

            return model;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<ProjetoViewModel>>> ObterPorId(Guid id)
        {
            var dev = await _projetoRepository.ObterPorId(id);
            if (dev == null) return NotFound();
            var model = _mapper.Map<ProjetoViewModel>(dev);

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<ProjetoViewModel>> Adicionar(ProjetoViewModel desenvolvedorViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _projetoService.Adicionar(_mapper.Map<Projeto>(desenvolvedorViewModel));
            return CustomResponse();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProjetoViewModel>> Atualizar(Guid id, ProjetoViewModel desenvolvedorViewModel)
        {
            if (id != desenvolvedorViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(desenvolvedorViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _projetoService.Atualizar(_mapper.Map<Projeto>(desenvolvedorViewModel));

            return CustomResponse(desenvolvedorViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProjetoViewModel>> Remover(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _projetoService.Remover(id);

            return CustomResponse();
        }
    }
}