using AutoMapper;
using Flunt.Notifications;
using LTS.Domain.Commands;
using LTS.Domain.Commands.Contracts;
using LTS.Domain.Commands.Project;
using LTS.Domain.Entities;
using LTS.Domain.Handlers.Contracts;
using LTS.Domain.Interfaces;
using System.Threading.Tasks;

namespace LTS.Domain.Handlers
{
    public class ProjectHandler :
        Notifiable,
        IHandler<CreateProjectCommand>,
        IHandler<UpdateProjectCommand>,
        IHandler<DeleteProjectCommand>,
        IHandler<AddDeveloperInProjectCommand>,
        IHandler<RemoveDeveloperFromProjectCommand>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IDeveloperRepository _developerRepository;
        private readonly IMapper _mapper;
        public ProjectHandler(IProjectRepository projectRepository, IDeveloperRepository developerRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _developerRepository = developerRepository;
            _mapper = mapper;
        }
        public async Task<ICommandResult> Handle(CreateProjectCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Operação inválida", command.Notifications);


            var developer = _mapper.Map<Project>(command);

            await _projectRepository.AddAsync(developer);

            return new GenericCommandResult(true, "Projeto criado com sucesso", developer);

        }

        public async Task<ICommandResult> Handle(UpdateProjectCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Operação inválida", command.Notifications);

            var projectDb = await _projectRepository.GetByIdAsync(command.Id);

            if (projectDb == null)
                return new GenericCommandResult(false, "Projeto não encontrado", command.Notifications);


            _mapper.Map(command, projectDb);

            await _projectRepository.UpdateAsync(projectDb);

            return new GenericCommandResult(true, "Projeto alterado com sucesso", projectDb);

        }

        public async Task<ICommandResult> Handle(DeleteProjectCommand command)
        {

            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Operação inválida", command.Notifications);

            var projectDb = await _projectRepository.GetByIdAsync(command.Id);

            if (projectDb == null)
                return new GenericCommandResult(false, "Projeto não encontrado", command.Notifications);


            await _projectRepository.DeleteAsync(command.Id);

            return new GenericCommandResult(true, "Projeto removido com sucesso", projectDb);
        }

        public async Task<ICommandResult> Handle(AddDeveloperInProjectCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Operação inválida", command.Notifications);

            var projectDb = await _projectRepository.GetProjectWithDevelopersProject(command.ProjectId);

            if (projectDb == null)
                return new GenericCommandResult(false, "Projeto não encontrado", command.Notifications);

            var developerDb = await _developerRepository.GetByIdAsync(command.DeveloperId);

            if (developerDb == null)
                return new GenericCommandResult(false, "Desenvolvedor não encontrado", command.Notifications);

            var developerProject = new DeveloperProject
            {
                Project = projectDb,
                Developer = developerDb
            };

            projectDb.DeveloperProjects.Add(developerProject);

            await _projectRepository.UpdateAsync(projectDb);

            return new GenericCommandResult(true, "Desenvolvedor adicionado ao projeto com sucesso", new
            {
                DeveloperName = developerDb.Name,
                ProjectName = projectDb.Name

            });
        }

        public async Task<ICommandResult> Handle(RemoveDeveloperFromProjectCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Operação inválida", command.Notifications);


            var projectDb = await _projectRepository.GetProjectWithDevelopersProject(command.ProjectId);

            if (projectDb == null)
                return new GenericCommandResult(false, "Projeto não encontrado", command.Notifications);

            var developerDb = await _developerRepository.GetByIdAsync(command.DeveloperId);

            if (developerDb == null)
                return new GenericCommandResult(false, "Desenvolvedor não encontrado", command.Notifications);


            var developersProjects = projectDb.DeveloperProjects;

            DeveloperProject founded = null;
            foreach (var developerProject in developersProjects)
            {
                if (developerProject.ProjectId == command.ProjectId && developerProject.DeveloperId == command.DeveloperId)
                    founded = developerProject;
            }

            await _projectRepository.RemoveDeveloperFromProject(founded);

            return new GenericCommandResult(true, "Desenvolvedor removido do projeto com sucesso", new
            {
                DeveloperName = developerDb.Name,
                ProjectName = projectDb.Name

            });
        }
    }
}
