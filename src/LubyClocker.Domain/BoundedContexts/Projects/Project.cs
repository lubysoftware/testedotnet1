using System;
using System.Collections.Generic;
using LubyClocker.Domain.Abstractions;

namespace LubyClocker.Domain.BoundedContexts.Projects
{
    public class Project : Entity
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Description { get; set; }

        public Project()
        {
            
        }
        public Project(string name, DateTime startDate, DateTime deliveryDate, string description)
        {
            Name = name;
            StartDate = startDate;
            DeliveryDate = deliveryDate;
            Description = description;
        }

        public ICollection<ProjectMember> Members { get; set; }
    }
}