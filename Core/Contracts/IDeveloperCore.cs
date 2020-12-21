using Core.Core;
using Core.ViewModels;
using FabricaDeProjetos.Domain.Entities;

namespace Core.Contracts
{
    public interface IDeveloperCore : IEntityCoreBase<Developer>
    {
        Developer GetLogin(string email);
        object LoginDeveloper(Login developer);
        object GetDeveloperById(int id);
        object GetDevelopers();
        FabricaDeProjetosResult AddDeveloper(DeveloperViewModel developer);
        FabricaDeProjetosResult UpdateDeveloper(DeveloperViewModel developer);
        FabricaDeProjetosResult DeleteDeveloper(int id);
    }
}
