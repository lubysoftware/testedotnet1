using System;
using System.Collections.Generic;
using System.Text;
using TimeSheetManager.Domain.Entities.DeveloperNS;

namespace TimeSheetManager.Domain.TimeSheetNS {
    public class Ranking {
        public Ranking() {
        }

        public Ranking(Guid Id, string Name, double WorkedTime) {
            this.Id = Id;
            this.Name = Name;
            this.WorkedTime = WorkedTime;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public double WorkedTime { get; set; }
    }
}