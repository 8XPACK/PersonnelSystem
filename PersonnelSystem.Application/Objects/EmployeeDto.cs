using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelSystem.Application.Objects
{
    public class EmployeeDto
    {
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
        public string Email { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime DateOfDismissal { get; set; }
    }
}
