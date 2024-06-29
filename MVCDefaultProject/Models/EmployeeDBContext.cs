using Microsoft.EntityFrameworkCore;

namespace MVCDefaultProject.Models
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options): base(options)
        {

        }
        public virtual DbSet<Employee> Employee { get; set; }
    }
}
