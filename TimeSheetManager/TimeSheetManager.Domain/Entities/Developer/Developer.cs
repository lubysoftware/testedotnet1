using System;

namespace TimeSheetManager.Domain.Entities.Developer {
    public class Developer : Entity {
        public Developer() {
        }

        public Developer(string _Name){
            Name = _Name;
        }
        public string Name {get; set;}

        public void ChangeName(string _Name) {
            Name = _Name;
        }
    }
}