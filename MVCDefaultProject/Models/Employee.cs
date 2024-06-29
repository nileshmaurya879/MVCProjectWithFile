using System.ComponentModel.DataAnnotations;
using System.IO;

namespace MVCDefaultProject.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public int Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Notes { get; set; }
        public string? Marriage { get; set; }
        public byte[]? profileImage { get; set; }
    }
}
