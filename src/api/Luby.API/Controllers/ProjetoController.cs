namespace Luby.API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Luby.API.ViewModel;
    using Luby.Core.Interfaces.Repositories;
    using Luby.Core.Interfaces.Services;
    using Luby.Core.Model;
    using Luby.Core.Notificacoes;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/projeto")]
    public class ProjetoController : BaseController
    {
        private readonly IProjetoService _prjService;
        private readonly IProjetoRepository _prjRepo;
        private readonly IMapper _mapper;
        public ProjetoController(
            IMapper mapper,
            IProjetoService projetoService,
            IProjetoRepository projetoRepository,
            INotificador notificador
        ) : base(notificador) 
        { 
            _mapper = mapper;
            _prjRepo = projetoRepository;
            _prjService = projetoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjetoViewModel>>> GetAll()
        {
            var projetos = await _prjRepo.GetAll();

            return CustomResponse(_mapper.Map<IEnumerable<ProjetoViewModel>>(projetos));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProjetoViewModel>> GetById(int id)
        {
            var projeto = await _prjRepo.GetbyId(id);

            if(projeto == null) 
                return CustomResponse();

            return CustomResponse(_mapper.Map<ProjetoViewModel>(projeto));
        }

        [HttpPost]
        public async Task<ActionResult<ProjetoViewModel>> Create(ProjetoViewModel projetoViewModel)
        {
            if(!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _prjService.Add(_mapper.Map<Projeto>(projetoViewModel));

            return CustomResponse(projetoViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var projeto = await _prjRepo.GetbyId(id);

            if(projeto == null)
            {
                NotifierError("Não foi encontrado projeto com o Id informado!");   
                return CustomResponse();
            }

            await _prjService.Delete(id);

            return CustomResponse();
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProjetoViewModel projeto)
        {
            if(projeto.Id == null)
                ModelState.AddModelError(nameof(projeto.Id), "O campo Id é obrigatório!");

            if(!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _prjService.Update(_mapper.Map<Projeto>(projeto));

            return CustomResponse(projeto);
        }

    }
}