using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCDefaultProject.Dto;
using MVCDefaultProject.Interface;
using MVCDefaultProject.Models;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace MVCDefaultProject.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly IEmployeeRepository _employeeRepository;
        public readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository employeeRepository,IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = _employeeRepository.GetAllEmployee();
           
            return View(data);
        }
        public IActionResult AddEmployee()
        {
            var test = new GenderViewModel()
            {
                Genders = new List<SelectListItem>()
                {
                    new SelectListItem { Text = "Male", Value = "Male"},
                    new SelectListItem { Text = "Female", Value = "Female"}
                }
            };

            ViewModelDto viewModelDto = new ViewModelDto()
            {
                checkboxes = new List<checkboxOptions>()
                {
                    new checkboxOptions()
                    {
                        isSelected = true,
                        text ="test001",
                        value = "test001"
                    },
                    new checkboxOptions()
                    {
                        isSelected = false,
                        text ="test002",
                        value = "test002"
                    },
                    new checkboxOptions()
                    {
                        isSelected = false,
                        text ="test003",
                        value = "test003"
                    }
                }
            };
            EmployeeDto employeeDto = new EmployeeDto()
            {
                viewModelDto = viewModelDto
            };
            ViewBag.Gender = test.Genders;
            return View(employeeDto);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(IFormFile profileImage, EmployeeDto employee)
       {
            if (ModelState.IsValid)
            {
                Employee employee1 = new Employee()
                {
                    EmployeeName = employee.EmployeeName,
                    Gender = employee.Gender,
                    Age = employee.Age,
                    DateOfBirth = employee.DateOfBirth,
                    Marriage = employee.Marriage,
                    Notes = employee.Notes
                };

                if (profileImage != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        profileImage.CopyTo(ms);
                        employee1.profileImage = ms.ToArray();
                    }
                }
                await _employeeRepository.AddEmployee(employee1);
                return RedirectToAction("Index");
            }
            var test = new GenderViewModel()
            {
                Genders = new List<SelectListItem>()
                {
                    new SelectListItem { Text = "Male", Value = "Male"},
                    new SelectListItem { Text = "Female", Value = "Female"}
                }
            };
            ViewBag.Gender = test.Genders;
            return View();
            
        }
        public IActionResult UpdateEmployee(int id)
        {
            var data = _employeeRepository.GetEmployee(id).Result;
            var test = new GenderViewModel()
            {
                Genders = new List<SelectListItem>()
                {
                    new SelectListItem { Text = "Male", Value = "Male"},
                    new SelectListItem { Text = "Female", Value = "Female"}
                }
            };
            ViewBag.Gender = test.Genders;
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            await _employeeRepository.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
