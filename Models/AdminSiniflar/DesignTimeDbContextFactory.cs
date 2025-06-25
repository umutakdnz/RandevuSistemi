using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer("Server=LAPTOP-R5TO6TH6\\SQLEXPRESS;Database=DbRandevuSistemi;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

            return new Context(optionsBuilder.Options);
        }
    }
}
