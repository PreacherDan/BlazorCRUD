using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Shared
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int YearlyBudget { get; set; }

        public Department()
        {

        }

        //public Department(BlazorCRUD.Shared.DTOs.DepartmentDTO departmentDTO)
        //{
        //    this.ID = departmentDTO.ID;
        //    this.Name = departmentDTO.Name;
        //    this.Location = departmentDTO.Location;
        //    this.YearlyBudget = departmentDTO.YearlyBudget;
        //}
    }
}