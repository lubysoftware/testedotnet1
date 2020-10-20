using System;
using System.Collections.Generic;
using System.Text;
using TimeSheetManager.Domain.Entities.DeveloperNS;

namespace TimeSheetManager.Domain.TimeSheetNS {
    public class Ranking {
        public Ranking() {
        }

        public Ranking(Guid DevId, string Name, double WorkedTime) {
            this.DevId = DevId;
            this.Name = Name;
            this.WorkedTime = WorkedTime;
        }

        public Guid DevId { get; set; }
        public string Name { get; set; }
        public double WorkedTime { get; set; }
    }
}