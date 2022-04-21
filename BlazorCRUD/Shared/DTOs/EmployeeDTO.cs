using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Shared.DTOs
{
    public class EmployeeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Salary { get; set; }

        public DepartmentDTO? DepartmentDTO { get; set; } //navigation property
        public byte DepartmentID { get; set; }

        public EmployeeDTO()
        {

        }

        public EmployeeDTO(Employee employee)
        {
            this.ID = employee.ID;
            this.Name = employee.Name;
            this.Surname = employee.Surname;
            this.Salary = employee.Salary;

            if (employee.Department != null) this.DepartmentDTO = new DepartmentDTO(employee.Department);
            this.DepartmentID = employee.DepartmentID;
        }
    }
}
