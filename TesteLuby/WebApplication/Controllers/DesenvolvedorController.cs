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
    public class DesenvolvedorController : MainController
    {
        private readonly IDesenvolvedorRepository _desenvolvedorRepository;
        private readonly IDesenvolvedorService _desenvolvedorService;


        public DesenvolvedorController(
            INotificador notificador,
            IDesenvolvedorRepository desenvolvedorRepository,
            IMapper mapper,
            IDesenvolvedorService desenvolvedorService) : base(notificador)
        {
            _desenvolvedorRepository = desenvolvedorRepository;
            _mapper = mapper;
            _desenvolvedorService = desenvolvedorService;
        }

        private IMapper _mapper { get; }

        [HttpGet]
        public async Task<IEnumerable<DesenvolvedorViewModel>> ObterTodos()
        {
            var dev = await _desenvolvedorRepository.ObterTodos();
            var model = _mapper.Map<IEnumerable<DesenvolvedorViewModel>>(dev);

            return model;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<DesenvolvedorViewModel>>> ObterPorId(Guid id)
        {
            var dev = await _desenvolvedorRepository.ObterPorId(id);
            if (dev == null) return NotFound();
            var model = _mapper.Map<DesenvolvedorViewModel>(dev);

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<DesenvolvedorViewModel>> Adicionar(DesenvolvedorViewModel desenvolvedorViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _desenvolvedorService.Adicionar(_mapper.Map<Desenvolvedor>(desenvolvedorViewModel));
            return CustomResponse();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<DesenvolvedorViewModel>> Atualizar(Guid id,
            DesenvolvedorViewModel desenvolvedorViewModel)
        {
            if (id != desenvolvedorViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(desenvolvedorViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _desenvolvedorService.Atualizar(_mapper.Map<Desenvolvedor>(desenvolvedorViewModel));

            return CustomResponse(desenvolvedorViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<DesenvolvedorViewModel>> Remover(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _desenvolvedorService.Remover(id);

            return CustomResponse();
        }
    }
}