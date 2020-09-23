using API.ViewModel;
using AutoMapper;
using Business.Interfaces;
using Business.Interfaces.Repository;
using Business.Interfaces.Services;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/developer")]
    public class DeveloperController : MainController
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IMapper _mapper;
        private readonly IDeveloperService _developerService;

        public DeveloperController(IDeveloperRepository developerRepository, IMapper mapper, IDeveloperService developerService, INotifier notifier) : base(notifier)
        {
            _developerRepository = developerRepository;
            _mapper = mapper;
            _developerService = developerService;
        }

        [HttpGet]
        public async Task<IEnumerable<DeveloperViewModel>> GetAll()
        {
            var developers = _mapper.Map<IEnumerable<DeveloperViewModel>>(await _developerRepository.GetAll());

            return developers;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DeveloperViewModel>> GetById(Guid id)
        {
            var developer = _mapper.Map<DeveloperViewModel>(await _developerRepository.GetById(id));

            if (developer == null)
                return NotFound();

            return developer;
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<DeveloperViewModel>> Remove(Guid id)
        {
            var developer = _mapper.Map<DeveloperViewModel>(await _developerRepository.GetByIdToRemove(id));

            if (developer == null)
                return NotFound();

            try
            {
                await _developerService.Remove(id);
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);
                return CustomResponse();
            }

            return CustomResponse(developer);
        }

        [HttpPost]
        public async Task<ActionResult<DeveloperViewModel>> Add(DeveloperViewModel developer)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            try
            {
                await _developerService.Add(_mapper.Map<Developer>(developer));
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);
                return CustomResponse();
            }

            return CustomResponse(developer);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<DeveloperViewModel>> Update(Guid id, DeveloperViewModel developer)
        {
            if (id != developer.Id)
            {
                NotifyError("O id informado não é o mesmo que foi informado na query");

                return CustomResponse(developer);
            }

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            try
            {
                await _developerService.Update(_mapper.Map<Developer>(developer));
            }
            catch (Exception ex)
            {
                return CustomResponse(ex.Message);
            }

            return CustomResponse(developer);
        }
    }
}
