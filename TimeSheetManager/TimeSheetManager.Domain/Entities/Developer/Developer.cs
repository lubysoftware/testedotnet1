using System;
using System.Collections.Generic;
using TimeSheetManager.Domain.Entities.TimeSheetNS;

namespace TimeSheetManager.Domain.Entities.DeveloperNS {
    public class Developer : Entity {
        public Developer() {
        }

        public Developer(string _Name){
            Name = _Name;
        }
        public string Name {get; set; }

        public List<TimeSheet> WorkTime { get; }

        public void ChangeName(string _Name) {
            Name = _Name;
        }
    }
}