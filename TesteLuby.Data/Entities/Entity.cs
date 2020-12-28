using System;
using System.Collections.Generic;
using System.Text;

namespace TesteLuby.Data.Entities
{
    public class Entity
    {
        public int ID { get; private set; }

        public void SetID(int id) => ID = id;
    }
}
