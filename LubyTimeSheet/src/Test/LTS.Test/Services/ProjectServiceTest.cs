using FluentAssertions;
using LTS.Domain.Entities;
using LTS.Domain.Services;
using LTS.Test.Fakes;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xunit;

namespace LTS.Test.Services
{
    public class ProjectServiceTest : LubyIntegrationTestBase
    {
        private ProjectService _projectService;

        public ProjectServiceTest()
        {
            _projectService = ResolveCollection<ProjectService>();
        }


        [Fact]
        public async Task Should_get_project_by_id()
        {
            var project = ProjectFake.Default(Guid.NewGuid());

            PersistEntities(project);

            var found = await _projectService.GetById(project.Id);

            var projectFound = found.Data as Project;

            var projectDb = _context.Set<Project>().First();

            found.Should().NotBeNull();
            projectDb.Name.Should().BeEquivalentTo(projectFound.Name);
        }
    }
}
