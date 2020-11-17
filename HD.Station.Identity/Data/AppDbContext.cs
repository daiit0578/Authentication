using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace HD.Station.Identity.Data
{
    public class AppDbContext:IdentityDbContext
    {
        // IdentityDbContext Contains all the tables
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base (options)
        {

        }
    }
}
