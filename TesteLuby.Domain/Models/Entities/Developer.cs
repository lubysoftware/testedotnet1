using TesteLuby.Domain.Attributes;

namespace TesteLuby.Domain.Models.Entities
{
    [Entity("developer", "System developer", true)]
    public class Developer : EntityModels
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}