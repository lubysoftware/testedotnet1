using Core.Core;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using FabricaDeProjetos.Domain.Entities;

namespace Core.Contracts
{
    public interface IAssessmentsCore : IEntityCoreBase<Assessments>
    {
        IEnumerable<Assessments> GetAssessmentsByProject(int idProject);
        FabricaDeProjetosResult AddAssessments(AssessmentsViewModel assessments);
    }
}
