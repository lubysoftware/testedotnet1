using System;
using LubyClocker.Application.BoundedContexts.Developers.ViewModels;
using LubyClocker.CrossCuting.Shared.Common;

namespace LubyClocker.Application.BoundedContexts.Developers.Queries.FindById
{
    public class FindDeveloperByIdQuery : Query<DeveloperViewModel>
    {
        public Guid Id { get; set; }
        
        public FindDeveloperByIdQuery IncludeId(Guid id)
        {
            Id = id;

            return this;
        }
    }
}