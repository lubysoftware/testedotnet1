using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;


namespace FabricaDeProjetos.Domain.Helpers
{
    public class AppSettings
    {
        private IConfiguration _configuration;

        public AppSettings()
        {
            Secret = "fgg45f1d55FHhsd5ffrhuKA5sdgd5ggDFS5gG5775sdf";
        }
        public string Secret { get; set; }


    }
}
