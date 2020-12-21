using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class DeveloperViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UrlImage { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
