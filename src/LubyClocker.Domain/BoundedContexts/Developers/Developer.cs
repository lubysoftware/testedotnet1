using System.Collections.Generic;
using LubyClocker.Domain.Abstractions;
using LubyClocker.Domain.BoundedContexts.Projects;

namespace LubyClocker.Domain.BoundedContexts.Developers
{
    public class Developer : Entity
    {
        public string FullName { get; set; }
        public string Commentary { get; set; }
        public QualificationLevel Qualification { get; set; }
        
        public ICollection<ProjectMember> Projects { get; set; }


        public Developer(string fullName, string commentary, QualificationLevel qualification)
        {
            FullName = fullName;
            Commentary = commentary;
            Qualification = qualification;
        }
    }
}