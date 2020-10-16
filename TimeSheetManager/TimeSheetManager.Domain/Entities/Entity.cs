using System;

namespace TimeSheetManager.Domain.Entities {
    public abstract class Entity {
        protected Entity(){
            Id = Guid.NewGuid();
        }
        public Guid Id {get; set;}
    }
}