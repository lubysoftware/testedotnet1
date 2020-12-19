using Core.Core;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using FabricaDeProjetos.Domain.Entities;

namespace Core.Contracts
{
    public interface IProjectCore : IEntityCoreBase<Project>
    {

        IEnumerable<Project> GetProjectsById(int id);
        IEnumerable<Project> GetProjectsByIdDeveloper(int id);
        IEnumerable<Project> GetProjectsActive();
        IEnumerable<Project> GetProjectsNoActive();
        FabricaDeProjetosResult AddProject(ProjectViewModel projects);
        FabricaDeProjetosResult UpdateProject(ProjectViewModel projects);
        FabricaDeProjetosResult DeleteProject(ProjectViewModel projects);

    }
}
