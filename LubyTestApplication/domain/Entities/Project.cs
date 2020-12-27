using System.Collections.Generic;

namespace test.domain.Entities
{
    public class Project : Base
    {
        public Project()
        {
            DeveloperOnProject = new HashSet<DeveloperOnProject>();
        }

        public ICollection<DeveloperOnProject> DeveloperOnProject { get; set; }

    }
}
