using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiRestWebClient
{
    internal class CorsAuthorizationFilterFactory : IFilterMetadata
    {
        private string v;

        public CorsAuthorizationFilterFactory(string v)
        {
            this.v = v;
        }
    }
}