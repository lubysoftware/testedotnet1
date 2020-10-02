using TesteLuby.Domain.Attributes;

namespace TesteLuby.Domain.Models.Entities
{
    [Entity("projectdeveloper", "System projectdeveloper", true)]
    
    public class ProjectDeveloper : EntityModels
    {

        public int DeveloperId { get; set; }
        public int ProjectId { get; set; }
    }
}
