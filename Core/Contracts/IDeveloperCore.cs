using System;
using System.Collections.Generic;
using System.Text;
using Core.Core;
using Core.ViewModels;
using FabricaDeProjetos.Domain.Entities;

namespace Core.Contracts
{
    public interface IDeveloperCore : IEntityCoreBase<Developer>
    {
        //User Get(string email, string password);
        Developer GetDeveloperByEmail(string email);
        object LoginDeveloper(Developer developer);
        IEnumerable<Developer> GetDeveloperById(int id);
        FabricaDeProjetosResult AddDeveloper(DeveloperViewModel developer);
        FabricaDeProjetosResult UpdateDeveloper(DeveloperViewModel developer);
        FabricaDeProjetosResult DeleteDeveloper(DeveloperViewModel developer);
    }
}
