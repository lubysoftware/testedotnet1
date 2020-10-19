using System;

namespace TimeSheetManager.Domain.Entities.Project {
    public class Project : Entity {
        public Project() {
        }

        public Project(string _Name){
            Name = _Name;
        }
        public string Name {get; set;}
        public void ChangeName(string _Name) {
            Name = _Name;
        }
    }
}