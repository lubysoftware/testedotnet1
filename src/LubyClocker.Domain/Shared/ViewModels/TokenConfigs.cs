namespace LubyClocker.Domain.Shared.ViewModels
{
    public class TokenConfigs
    {
        public string Secret { get; set; }
        public int Seconds { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Scope { get; set; }
    }
}