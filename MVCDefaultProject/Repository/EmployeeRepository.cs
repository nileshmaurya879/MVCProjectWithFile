using Microsoft.EntityFrameworkCore;
using MVCDefaultProject.Interface;
using MVCDefaultProject.Models;

namespace MVCDefaultProject.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        public readonly EmployeeDBContext _employeeDBContext;
        public EmployeeRepository(EmployeeDBContext employeeDBContext)
        {
            _employeeDBContext = employeeDBContext;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            var data = _employeeDBContext.Employee.ToList();
            return data;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            var data = await _employeeDBContext.Employee.Where(x => x.EmployeeId == employeeId).FirstOrDefaultAsync(); ;
            return data;
        }
        public async Task<bool> AddEmployee(Employee employee)
        {
            await _employeeDBContext.Employee.AddAsync(employee);
            await _employeeDBContext.SaveChangesAsync();
            return true;    
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var data = await GetEmployee(employee.EmployeeId);
            if(data != null)
            {
                data.EmployeeName = employee.EmployeeName;
                data.Age = employee.Age;
                data.Marriage = employee.Marriage;
                data.Notes = employee.Notes;
            }
             _employeeDBContext.Employee.Update(data);
            await _employeeDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteEmployee(int id)
        {
            var data = await GetEmployee(id);
            if (data != null)
            {
                _employeeDBContext.Employee.Remove(data);
                await _employeeDBContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
