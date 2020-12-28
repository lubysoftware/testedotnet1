using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteLuby.Interfaces.DTO
{
    public class DeveloperDTO
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        protected DeveloperDTO() { }

        public DeveloperDTO(int? id, string name)
        {
            if (id.HasValue)
                ID = id.Value;
            Name = name;
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Name))
                return false;

            return true;
        }
    }
}
