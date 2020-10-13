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

    [Route("api/dev")]
    public class DesenvolvedorController : BaseController
    {
        private readonly IDesenvolvedorRepository _devRepo;
        private readonly IDesenvolvedorService _devService;
        private readonly IMapper _mapper; 
        public DesenvolvedorController(
            IMapper mapper,
            IDesenvolvedorService desenvolvedorService,
            IDesenvolvedorRepository desenvolvedorRepository,
            INotificador notificador
        ) : base(notificador)
        {
            _devRepo = desenvolvedorRepository;
            _devService = desenvolvedorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesenvolvedorViewModel>>> GetAll()
        {
            var devViewModel = _mapper.Map<IEnumerable<DesenvolvedorViewModel>>(await _devRepo.GetAll());

            return CustomResponse(devViewModel);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DesenvolvedorViewModel>> GetById(int id)
        {
            var dev =  await _devRepo.GetbyId(id);

            if(dev == null)
            {
                NotifierError("Não existe registro com o Id informado");
                return CustomResponse();
            }

            return CustomResponse(_mapper.Map<DesenvolvedorViewModel>(dev));
        }

        [HttpGet("{id:int}/projetos")]
        public async Task<ActionResult<ProjetoViewModel>> GetProjetos(int id)
        {
            var projetos = await _devRepo.GetProjetos(id);

            if(projetos == null) 
            {
                NotifierError("Não existem projetos cadastrados com esse desenvolvedor!");
                return CustomResponse();
            }

            return CustomResponse(_mapper.Map<IEnumerable<ProjetoViewModel>>(projetos));
        }

        [HttpPost]
        public async Task<ActionResult<DesenvolvedorViewModel>> Create(DesenvolvedorViewModel desenvolvedorViewModel)
        {
            if(!ModelState.IsValid)
                CustomResponse(ModelState);

            await _devService.Add(_mapper.Map<Desenvolvedor>(desenvolvedorViewModel));

            return CustomResponse(desenvolvedorViewModel);
        }

        [HttpPut]
        public async Task<ActionResult<DesenvolvedorViewModel>> Update(DesenvolvedorViewModel desenvolvedorViewModel)
        {
            if(desenvolvedorViewModel.Id == null)
                ModelState.AddModelError(nameof(desenvolvedorViewModel.Id), "O campo Id é obrigatório!");

            if(!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _devService.Update(_mapper.Map<Desenvolvedor>(desenvolvedorViewModel));

            return CustomResponse(desenvolvedorViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _devService.Delete(id);

            return CustomResponse();
        }
    }
}