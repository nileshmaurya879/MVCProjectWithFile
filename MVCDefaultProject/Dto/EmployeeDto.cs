using Microsoft.AspNetCore.Mvc.Rendering;
using MVCDefaultProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCDefaultProject.Dto
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        public int Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string? Marriage { get; set; }
        public string? Notes { get; set; }
        //public string profileImage { get; set; }
        public ViewModelDto viewModelDto { get; set; }
        public List<string> Sports { get; set; }

    }


    public class GenderViewModel
    {
        public List<SelectListItem> Genders { get; set; }
    }


}
