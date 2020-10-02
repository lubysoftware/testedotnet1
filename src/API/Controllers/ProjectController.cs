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
    [Route("api/project")]
    public class ProjectController : MainController
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly IProjectService _projectService;

        public ProjectController(IProjectRepository developerRepository, IMapper mapper, IProjectService developerService, INotifier notifier, IUser user) : base(notifier, user)
        {
            _projectRepository = developerRepository;
            _mapper = mapper;
            _projectService = developerService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProjectViewModel>> GetAll()
        {
            var projects = _mapper.Map<IEnumerable<ProjectViewModel>>(await _projectRepository.GetAll());

            return projects;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProjectViewModel>> GetById(Guid id)
        {
            var project = _mapper.Map<ProjectViewModel>(await _projectRepository.GetById(id));

            if (project == null)
                return NotFound();

            return project;
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProjectViewModel>> Remove(Guid id)
        {
            var project = _mapper.Map<ProjectViewModel>(await _projectRepository.GetProjectByIdToRemove(id));

            if (project == null)
                return NotFound();

            try
            {
                await _projectService.Remove(id);
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);
                return CustomResponse();
            }

            return CustomResponse(project);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectViewModel>> Add(ProjectViewModel project)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            try
            {
                await _projectService.Add(_mapper.Map<Project>(project));
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);
                return CustomResponse();
            }

            return CustomResponse(project);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProjectViewModel>> Update(Guid id, ProjectViewModel project)
        {
            if (id != project.Id)
            {
                NotifyError("O id informado não é o mesmo que foi informado na query");

                return CustomResponse(project);
            }

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            try
            {
                await _projectService.Update(_mapper.Map<Project>(project));
            }
            catch (Exception ex)
            {
                return CustomResponse(ex.Message);
            }

            return CustomResponse(project);
        }
    }
}
