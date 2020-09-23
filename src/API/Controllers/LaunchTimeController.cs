using API.ViewModel;
using AutoMapper;
using Business.Interfaces;
using Business.Interfaces.Repository;
using Business.Interfaces.Services;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/launchTime")]
    public class LaunchTimeController : MainController
    {
        private readonly ILaunchTimeRepository _launchTimeRepository;
        private readonly IMapper _mapper;
        private readonly ILaunchTimeService _launchTimeService;

        public LaunchTimeController(ILaunchTimeRepository launchTimeRepository, IMapper mapper, ILaunchTimeService launchTimeService, INotifier notifier, IUser user) : base(notifier, user)
        {
            _launchTimeRepository = launchTimeRepository;
            _mapper = mapper;
            _launchTimeService = launchTimeService;
        }

        [HttpGet]
        public async Task<IEnumerable<LaunchTimeViewModel>> GetAll()
        {
            var launchTimers = _mapper.Map<IEnumerable<LaunchTimeViewModel>>(await _launchTimeRepository.GetAll());

            return launchTimers;
        }

        [HttpGet("ranking")]
        public async Task<ActionResult> GetRanking()
        {
            var resultAll = _mapper.Map<IEnumerable<LaunchTimeViewModel>>(await _launchTimeRepository.GetAll());

            if(resultAll != null && resultAll.Count() > 0)
            {
                var teste = resultAll.GroupBy(x => x.IdDeveloper).Select(y => new
                {
                    Id = y.Key,
                    Soma = y.Sum(x=>x.ProxyHoras)
                }).OrderByDescending(z=>z.Soma).Take(5);

                return Ok(teste);
            }

            return null;
        }



        [HttpGet("{id:guid}")]
        public async Task<ActionResult<LaunchTimeViewModel>> GetById(Guid id)
        {
            var launchTime = _mapper.Map<LaunchTimeViewModel>(await _launchTimeRepository.GetById(id));

            if (launchTime == null)
                return NotFound();

            return launchTime;
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<LaunchTimeViewModel>> Remove(Guid id)
        {
            var launchTime = _mapper.Map<LaunchTimeViewModel>(await _launchTimeRepository.GetByIdToRemove(id));

            if (launchTime == null)
                return NotFound();

            try
            {
                await _launchTimeService.Remove(id);
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);
                return CustomResponse();
            }

            return CustomResponse(launchTime);
        }

        [HttpPost]
        public async Task<ActionResult<LaunchTimeViewModel>> Add(LaunchTimeViewModel launchTime)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            try
            {
                await _launchTimeService.Add(_mapper.Map<LaunchTime>(launchTime));
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);
                return CustomResponse();
            }

            return CustomResponse(launchTime);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<LaunchTimeViewModel>> Update(Guid id, LaunchTimeViewModel launchTime)
        {
            if (id != launchTime.Id)
            {
                NotifyError("O id informado não é o mesmo que foi informado na query");

                return CustomResponse(launchTime);
            }

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            try
            {
                await _launchTimeService.Update(_mapper.Map<LaunchTime>(launchTime));
            }
            catch (Exception ex)
            {
                return CustomResponse(ex.Message);
            }

            return CustomResponse(launchTime);
        }
    }
}
