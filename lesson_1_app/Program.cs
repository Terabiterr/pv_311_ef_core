

using lesson_1_app.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

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
                var product = new Product
                {
                    Name = "New Product",
                    Price = 10.00m
                };
                context.Products.Add(product);
                context.SaveChanges();
            }
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
