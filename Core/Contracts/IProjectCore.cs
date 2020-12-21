using Core.Core;
using Core.ViewModels;
using FabricaDeProjetos.Domain.Entities;

namespace Core.Contracts
{
    public interface IProjectCore : IEntityCoreBase<Project>
    {

        object GetProjectsById(int id);
        object GetProjectsByIdDeveloper(int id);
        object GetProjectActive();
        object GetProjectNoActive();
        FabricaDeProjetosResult AddProject(ProjectViewModel projects);
        FabricaDeProjetosResult UpdateProject(ProjectViewModel projects);
        FabricaDeProjetosResult DeleteProject(int id);

    }
}