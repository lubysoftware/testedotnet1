using Core.Contracts;
using Core.Core;
using Core.Core.Base;
using Core.Server;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FabricaDeProjetos.Core;
using FabricaDeProjetos.Domain.Entities;
using System.Collections.Generic;
using Core.ViewModels;

namespace Core
{
    public class DeveloperCore : EntityCoreBase<Developer>, IDeveloperCore
    {
        #region [ Propriedades / Construtor ]

        public ITokenServiceCore _tokenServiceCore;
        private IEntityCoreBase<Developer> _developerCore;

        public DeveloperCore(ITokenServiceCore tokenServiceCore)
        {
            _tokenServiceCore = tokenServiceCore;
        }

        internal DeveloperCore(ServerContainer serverContainer)
            : base(serverContainer)
        {
        }

        #endregion [ Propriedades / Construtor ]

        #region [ Configurações de Conexão ]

        protected override void StartDependenciesConnections()
        {
            _developerCore = new EntityCoreBase<Developer>(_Server);
        }

        #endregion [ Configurações de Conexão ]

        public Developer GetDeveloperByEmail(string email)
        {
            var developer = _developerCore.SelectFirst(s => s.Email == email && s.Active);
            return developer;
        }

        public object LoginDeveloper(Developer developer)
        {
            var developerServer = _developerCore.SelectFirst(s => s.Email == developer.Email && s.Password == developer.Password);

            if (developer == null || developerServer == null || string.IsNullOrEmpty(developerServer.Email) || string.IsNullOrEmpty(developer.Password))
                return NotFound("Usuário ou senha inválidos");

            var developerToken = _tokenServiceCore.GenerateToken(developer);

            // Oculta a senha
            developer.Password = "";

            return new
            {
                user = developerServer,
                token = developerToken
            };

        }

        public IEnumerable<Developer> GetDeveloperById(int id)
        {
            IEnumerable<Developer> developer = _developerCore.Select(s => s.Id == id);
            return developer;
        }

        public FabricaDeProjetosResult AddDeveloper(DeveloperViewModel developerVM)
        {
            try
            {
                using (var dbContext = _Repository.NewConnection())
                {
                    dbContext.BeginTransaction();

                    if (developerVM != null)
                    {
                        Developer developer = new Developer()
                        {
                            Email = developerVM.Email,
                            Password = developerVM.Password,
                            Name = developerVM.Name,
                            LastName = developerVM.LastName,
                            Description = developerVM.Description,
                            Role = developerVM.Role,
                            Active = developerVM.Active,
                            CreationDate = developerVM.CreationDate,
                            ChangeDate = developerVM.ChangeDate,
                            EndDate = developerVM.EndDate,
                        };
                        var developerInsert = _developerCore.Insert(developer, dbContext);
                        dbContext.Commit();
                        return new FabricaDeProjetosResult(HttpStatusCode.OK, true, "Desenvolvedor adicionado com sucesso.", developerInsert);
                    }
                    else
                    {
                        return new FabricaDeProjetosResult(HttpStatusCode.OK, false, "Erro ao cadastrar desenvolvedor.");
                    }
                }
            }
            catch (Exception ex)
            {
                return new FabricaDeProjetosResult(HttpStatusCode.OK, false, "Erro ao cadastrar desenvolvedor. " + ex.Message);
            }
        }

        public FabricaDeProjetosResult UpdateDeveloper(DeveloperViewModel developerVM)
        {
            try
            {
                using (var dbContext = _Repository.NewConnection())
                {
                    dbContext.BeginTransaction();

                    Developer developer = _developerCore.SelectFirst(p => p.Id == developerVM.Id && p.Active);

                    if (developer != null)
                    {
                        developer.Email = developerVM.Email;
                        developer.Password = developerVM.Password;
                        developer.Name = developerVM.Name;
                        developer.LastName = developerVM.LastName;
                        developer.Description = developerVM.Description;
                        developer.Role = developerVM.Role;
                        developer.Active = developerVM.Active;
                        developer.CreationDate = developerVM.CreationDate;
                        developer.ChangeDate = developerVM.ChangeDate;
                        developer.EndDate = developerVM.EndDate;


                        var developerUpdate = _developerCore.Update(developer, dbContext);
                        dbContext.Commit();
                        return new FabricaDeProjetosResult(HttpStatusCode.OK, true, "Desenvolvedor alterado com sucesso.", developerUpdate);
                    }
                    else
                    {
                        return new FabricaDeProjetosResult(HttpStatusCode.OK, false, "Erro ao alterar desenvolvedor.");
                    }
                }
            }
            catch (Exception ex)
            {
                return new FabricaDeProjetosResult(HttpStatusCode.OK, false, "Erro ao alterar desenvolvedor. " + ex.Message);
            }
        }

        public FabricaDeProjetosResult DeleteDeveloper(DeveloperViewModel developerVM)
        {
            try
            {
                using (var dbContext = _Repository.NewConnection())
                {
                    dbContext.BeginTransaction();

                    Developer developer = _developerCore.SelectFirst(p => p.Id == developerVM.Id);

                    if (developer != null)
                    {
                        var developerDelete = _developerCore.Delete(developer, dbContext);
                        dbContext.Commit();
                        return new FabricaDeProjetosResult(HttpStatusCode.OK, true, "Desenvolvedor excluído com sucesso.", developerDelete);
                    }
                    else
                    {
                        return new FabricaDeProjetosResult(HttpStatusCode.OK, false, "Erro ao excluir desenvolvedor.");
                    }
                }
            }
            catch (Exception ex)
            {
                return new FabricaDeProjetosResult(HttpStatusCode.OK, false, "Erro ao excluir desenvolvedor. " + ex.Message);
            }
        }

        private FabricaDeProjetosResult NotFound(string message)
        {
            return new FabricaDeProjetosResult(HttpStatusCode.OK, false, message);
        }

    }
}
