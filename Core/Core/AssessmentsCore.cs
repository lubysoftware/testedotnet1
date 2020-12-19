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

namespace Core.Core
{
    public class AssessmentsCore : EntityCoreBase<Assessments>, IAssessmentsCore
    {
        #region [ Propriedades / Construtor ]

        private IEntityCoreBase<Assessments> _assessmentsCore;

        public AssessmentsCore() { }

        internal AssessmentsCore(ServerContainer serverContainer)
            : base(serverContainer) { }

        #endregion [ Propriedades / Construtor ]


        public IEnumerable<Assessments> GetAssessmentsByProject(int idProject)
        {
            IEnumerable<Assessments> assessments = _assessmentsCore.Select(s => s.IdProject == idProject);
            return assessments;
        }

        public FabricaDeProjetosResult AddAssessments(AssessmentsViewModel assessmentsVM)
        {
            try
            {
                using (var dbContext = _Repository.NewConnection())
                {
                    dbContext.BeginTransaction();

                    if (assessmentsVM != null)
                    {
                        Assessments assessments = new Assessments()
                        {
                            Description = assessmentsVM.Description,
                            NumberStar = assessmentsVM.NumberStar,
                            IdProject = assessmentsVM.IdProject,
                            CreationDate = assessmentsVM.CreationDate

                        };
                        var assassementsInsert = _assessmentsCore.Insert(assessments, dbContext);
                        dbContext.Commit();
                        return new FabricaDeProjetosResult(HttpStatusCode.OK, true, "Avaliação adicionada com sucesso.", assassementsInsert);
                    }
                    else
                    {
                        return new FabricaDeProjetosResult(HttpStatusCode.OK, false, "Erro ao cadastrar avaliação.");
                    }
                }
            }
            catch (Exception ex)
            {
                return new FabricaDeProjetosResult(HttpStatusCode.OK, false, "Erro ao cadastrar Assessments. " + ex.Message);
            }
        }
    }
}
