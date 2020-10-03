﻿namespace TesteLuby.Domain.Models.Settings
{
    public class JwtSetting
    {
        public string Secret { get; set; }
        public int ExpiracaoMinutos { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
    }
}
