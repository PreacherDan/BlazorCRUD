using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Shared.DTOs
{
    public class DepartmentDTO
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int YearlyBudget { get; set; }

        public DepartmentDTO()
        {

        }

        public DepartmentDTO(Department department)
        {
            this.ID = department.ID;
            this.Name = department.Name;
            this.Location = department.Location;
            this.YearlyBudget = department.YearlyBudget;
        }
    }
}
