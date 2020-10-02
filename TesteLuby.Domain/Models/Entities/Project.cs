
using TesteLuby.Domain.Attributes;

namespace TesteLuby.Domain.Models.Entities
{
    [Entity("project", "System project", true)]
    public class Project : EntityModels
    {
        public string ProjectName { get; set; }

    }
}
