using System.Collections.Generic;

namespace test.domain.Entities
{
    public class Developer : Base
    {
        public Developer()
        {
            DeveloperOnProject = new HashSet<DeveloperOnProject>();
            //Hours = new HashSet<Hours>();
        }

        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<DeveloperOnProject> DeveloperOnProject { get; set; }
        //public ICollection<Hours> Hours { get; set; }
    }
}
