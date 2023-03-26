using Epicor2Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseEPICORDb.Data
{
    public class EpicorDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public EpicorDbContext(DbContextOptions<EpicorDbContext> options) : base(options)
        {

        }
    }
}
