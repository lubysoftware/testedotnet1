namespace Hours.Domain.Security
{
    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Isseur { get; set; }
        public int Seconds { get; set; }
    }
}
