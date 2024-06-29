using MVCDefaultProject.Models;

namespace MVCDefaultProject.Interface
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployee();
        Task<Employee> GetEmployee(int employeeId);
        Task<bool> AddEmployee(Employee employee);
        Task<bool> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(int id);
    }
}
