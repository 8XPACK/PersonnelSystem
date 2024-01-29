using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelSystem.Core.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public Guid? ParentId { get; set; }
        public Department Parent { get; set; }
        public ICollection<Department> ChildDepartments { get; set; }
    }
}
