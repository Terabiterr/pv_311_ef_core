using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace lesson_1_app
{
    public class AppDbContextc : DbContext
    {
        private readonly IConfiguration _configuration;
        public AppDbContextc(
            DbContextOptions<AppDbContextc> options, 
            IConfiguration configuration) 
            : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

        }
    }
}
