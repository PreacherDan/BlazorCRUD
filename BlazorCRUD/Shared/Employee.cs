using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorCRUD.Shared
{
    public class Employee
    {
        public int ID { get; set; }
        [Display(Name="First Name")]
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Salary { get; set; }
        
        public Department? Department { get; set; } //navigation property
        public byte DepartmentID { get; set; }
        
        public Employee()
        {
                
        }

        //public Employee(BlazorCRUD.Shared.DTOs.EmployeeDTO employeeDTO)
        //{
        //    this.ID = employeeDTO.ID;
        //    this.Name = employeeDTO.Name;
        //    this.Surname = employeeDTO.Surname;
        //    this.Department = new Department(employeeDTO.DepartmentDTO);
        //    this.DepartmentID = employeeDTO.DepartmentID;
        //    this.Salary = employeeDTO.Salary;
        //}
    }

    public class EmployeeDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        //[EnrolledAfter18YearsOld]
        public DateTime? BirthDate { get; set; }

        public DateTime? DateEnrolled { get; set; }

        public int? Salary { get; set; }

        public DepartmentDTO Department { get; set; }

        public byte DepartmentID { get; set; }

        public bool IsOnLeave { get; set; }

        public EmployeeDTO()
        {

        }
    }

    public class DepartmentDTO
    {
        public DepartmentDTO() { }

        public DepartmentDTO(Department department)
        {
            this.ID = department.ID;
            this.Name = department.Name;
            this.Location = department.Location;
            this.YearlyBudget = department.YearlyBudget;
        }

        public int ID { get; set; }

        public string Name { get; set; }


        public string Location { get; set; }

        // multiply * amount of employees in department, if budget exceedes when adding employee, fail validation for that employee's salary
        public int YearlyBudget { get; set; }
    }
}