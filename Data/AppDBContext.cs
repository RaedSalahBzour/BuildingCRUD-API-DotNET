using BuildingCRUD.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildingCRUD.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
