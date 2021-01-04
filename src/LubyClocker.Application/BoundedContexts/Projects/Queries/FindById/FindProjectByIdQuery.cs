using System;
using LubyClocker.Application.BoundedContexts.Projects.ViewModels;
using LubyClocker.CrossCuting.Shared.Common;

namespace LubyClocker.Application.BoundedContexts.Projects.Queries.FindById
{
    public class FindProjectByIdQuery : Query<ProjectViewModel>
    {
        public Guid Id { get; set; }
        
        public FindProjectByIdQuery IncludeId(Guid id)
        {
            Id = id;

            return this;
        }
    }
}