namespace Hours.Infra.Config
{
    public static class Connect
    {
        public static string ConnectString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
    }
}
