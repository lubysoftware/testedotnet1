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
    public class ProjectCore : EntityCoreBase<Project>, IProjectCore
    {
        #region [ Propriedades / Construtor ]

        private IEntityCoreBase<Project> _projectCore;

        public ProjectCore()
        {
           
        }

        internal ProjectCore(ServerContainer serverContainer)
            : base(serverContainer) { }

        #endregion [ Propriedades / Construtor ]

        #region [ Configurações de Conexão ]

        protected override void StartDependenciesConnections()
        {
            _projectCore = new EntityCoreBase<Project>(_Server);
        }

        #endregion [ Configurações de Conexão ]

        public object GetProjectsById(int id)
        {
            IEnumerable<Project> projects = _projectCore?.Select(s => s.Id == id);
            return projects;
        }

        public object GetProjectsByIdDeveloper(int idDeveloper)
        {
            IEnumerable<Project> projects = _projectCore.Select(s => s.IdDeveloper == idDeveloper);
            return projects;
        }

        public object GetProjectActive()
        {
            IEnumerable<Project> projects = _projectCore.Select(s => s.Active);
            return projects;
        }

        public object GetProjectNoActive()
        {
            IEnumerable<Project> projects = _projectCore.Select(s => !s.Active);
            return projects;
        }

        public FabricaDeProjetosResult AddProject(ProjectViewModel projectVM)
        {
            try
            {
                using (var dbContext = _Repository.NewConnection())
                {
                    dbContext.BeginTransaction();

                    if (projectVM != null)
                    {
                        Project project = new Project()
                        {
                            Title = projectVM.Title,
                            IdDeveloper = projectVM.IdDeveloper,
                            Description = projectVM.Description,
                            Active = projectVM.Active,
                            InitialDate = projectVM.InitialDate,
                            FinalDate = projectVM.FinalDate,
                            CreationDate = projectVM.CreationDate,
                            ChangeDate = projectVM.ChangeDate,
                        };
                        var projectInsert = _projectCore.Insert(project, dbContext);
                        dbContext.Commit();
                        return new FabricaDeProjetosResult(HttpStatusCode.OK, true, "Projeto adicionado com sucesso.", projectInsert);
                    }
                    else
                    {
                        return new FabricaDeProjetosResult(HttpStatusCode.OK, false, "Erro ao cadastrar projeto.");
                    }
                }
            }
            catch (Exception ex)
            {
                return new FabricaDeProjetosResult(HttpStatusCode.OK, false, "Erro ao cadastrar projeto. " + ex.Message);
            }
        }
         
        public FabricaDeProjetosResult UpdateProject(ProjectViewModel projectVM)
        {
            try
            {
                using (var dbContext = _Repository.NewConnection())
                {
                    dbContext.BeginTransaction();

                    Project project = _projectCore.SelectFirst(p => p.Id == projectVM.Id);

                    if (project != null)
                    {
                        project.Title = projectVM.Title;
                        project.IdDeveloper = projectVM.IdDeveloper;
                        project.Description = projectVM.Description;
                        project.Active = projectVM.Active;
                        project.InitialDate = projectVM.InitialDate;
                        project.FinalDate = projectVM.FinalDate;
                        project.CreationDate = projectVM.CreationDate;
                        project.ChangeDate = projectVM.ChangeDate;
                        project.EndDate = projectVM.EndDate;


                        var projectUpdate = _projectCore.Update(project, dbContext);
                        dbContext.Commit();
                        return new FabricaDeProjetosResult(HttpStatusCode.OK, true, "Projeto alterado com sucesso.", projectUpdate);
                    }
                    else
                    {
                        return new FabricaDeProjetosResult(HttpStatusCode.OK, false, "Erro ao alterar projeto.");
                    }
                }
            }
            catch (Exception ex)
            {
                return new FabricaDeProjetosResult(HttpStatusCode.OK, false, "Erro ao alterar projeto. " + ex.Message);
            }
        }

        public FabricaDeProjetosResult DeleteProject(int id)
        {
            try
            {
                using (var dbContext = _Repository.NewConnection())
                {
                    dbContext.BeginTransaction();

                    Project project = _projectCore.SelectFirst(p => p.Id == id);

                    if (project != null)
                    {
                        var projectDelete = _projectCore.DeletePermanent(project, dbContext);
                        dbContext.Commit();
                        return new FabricaDeProjetosResult(HttpStatusCode.OK, true, "Projeto excluído com sucesso.", projectDelete);
                    }
                    else
                    {
                        return new FabricaDeProjetosResult(HttpStatusCode.OK, false, "Erro ao excluir projeto.");
                    }
                }
            }
            catch (Exception ex)
            {
                return new FabricaDeProjetosResult(HttpStatusCode.OK, false, "Erro ao excluir projeto. " + ex.Message);
            }
        }


    }
}
