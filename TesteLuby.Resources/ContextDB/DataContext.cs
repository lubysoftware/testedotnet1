using TesteLuby.Domain.Contracts;
using TesteLuby.Domain.Models.Entities;
using TesteLuby.Resources.Entities.Mapp;
using TesteLuby.Resources.Repositories;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using System.Linq;
using Testeluby.ResourcesDB.Repositories;
using Testeluby.ResourcesDB.Entities.Mapp;

namespace TesteLuby.Resources.Context
{
    public class DataContext : IContext
    {
        private readonly IAppSettings _settings;
        public IDapperRepository<Developer> Developer { get; set; }
        public IDapperRepository<Project> Project { get; set; }
        public IDapperRepository<ProjectDeveloper> ProjectDeveloper { get; set; }

        public DataContext(IAppSettings appSettings)
        {
            _settings = appSettings;
            this.BuildRepositoriesAsync();
            this.BuildMappers();
        }

        private void BuildRepositoriesAsync()
        {
            Developer = new DeveloperRepository(_settings);
            Project = new ProjectRepository(_settings);
            ProjectDeveloper = new ProjectDeveloperRepository(_settings);
        }

        private void BuildMappers()
        {
            if (!FluentMapper.EntityMaps.Any()) // Passa todos mapeamentos do dapper criados aqui
            {
                FluentMapper.Initialize(
                    config =>
                    {
                        config.AddMap(new DeveloperMapp());
                        config.AddMap(new ProjectMapp());
                        config.AddMap(new ProjectDeveloperMapp());
                        config.AddMap(new BusinessHourMapp());
                        config.ForDommel();
                    });
            }
        }
    }
}