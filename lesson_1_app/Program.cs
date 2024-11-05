

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace lesson_1_app
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuildaer = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuildaer.UseSqlServer(connectionString);

            using (var context = new AppDbContext(optionsBuildaer.Options, config))
            {
                var products = context.Products.ToList();
                foreach (var p in products)
                {
                    Console.WriteLine(p);
                }
            }
        }
    }
}
