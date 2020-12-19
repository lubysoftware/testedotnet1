using Core.Contracts;
using Core.Core;
using Core.Core.Base;
using Core.Server;
using Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using FabricaDeProjetos.Domain.Entities;

namespace Core
{
    public class ProjectCore : EntityCoreBase<Project>, IProjectCore
    {

        #region [ Propriedades / Construtor ]

        private IEntityCoreBase<Project> _projectCore;

        public ProjectCore() { }

        internal ProjectCore(ServerContainer serverContainer)
            : base(serverContainer) { }

        #endregion [ Propriedades / Construtor ]


        public IEnumerable<Project> GetProjectsById(int id)
        {
            IEnumerable<Project> projects = _projectCore.Select(s => s.Id == id);
            return projects;
        }

        public IEnumerable<Project> GetProjectsByIdDeveloper(int idDeveloper)
        {
            IEnumerable<Project> projects = _projectCore.Select(s => s.IdDeveloper == idDeveloper);
            return projects;
        }

        public IEnumerable<Project> GetProjectsActive()
        {
            IEnumerable<Project> projects = _projectCore.Select(s => s.Active);
            return projects;
        }
        public IEnumerable<Project> GetProjectsNoActive()
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
                            EndDate = projectVM.EndDate,
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

                    Project project = _projectCore.SelectFirst(p => p.Id == projectVM.Id && p.Active);

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

        public FabricaDeProjetosResult DeleteProject(ProjectViewModel projectVM)
        {
            try
            {
                using (var dbContext = _Repository.NewConnection())
                {
                    dbContext.BeginTransaction();

                    Project project = _projectCore.SelectFirst(p => p.Id == projectVM.Id);

                    if (project != null)
                    {
                        var projectDelete = _projectCore.Delete(project, dbContext);
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
