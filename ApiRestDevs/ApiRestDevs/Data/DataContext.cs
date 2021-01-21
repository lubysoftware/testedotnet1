using Microsoft.EntityFrameworkCore;


namespace ApiRestDevs.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
              : base(options)
        {
        }

    }
}
