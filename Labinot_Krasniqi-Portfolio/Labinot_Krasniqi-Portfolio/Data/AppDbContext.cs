using Labinot_Krasniqi_Portfolio.Models;
using Microsoft.EntityFrameworkCore;

namespace Labinot_Krasniqi_Portfolio.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }



    }
}
