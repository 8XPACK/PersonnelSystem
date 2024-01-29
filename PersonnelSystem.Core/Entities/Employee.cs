using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelSystem.Core.Entities
{
    public class Employee
    {
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
        public string Email { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime DateOfDismissal { get; set; }
        public User User { get; set; }
        public Department Department { get; set; }
    }
}
