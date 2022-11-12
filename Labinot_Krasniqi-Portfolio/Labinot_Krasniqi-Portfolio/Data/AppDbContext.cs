using Microsoft.EntityFrameworkCore;

namespace Labinot_Krasniqi_Portfolio.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

    }
}
