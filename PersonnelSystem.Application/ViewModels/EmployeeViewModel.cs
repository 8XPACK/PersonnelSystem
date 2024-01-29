using PersonnelSystem.Application.Objects;
using PersonnelSystem.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelSystem.Application.ViewModels
{
    public class EmployeeViewModel
    {
        public PageViewModel PageInfo { get; set; }
        public IEnumerable<EmployeeDto> Users { get; set; }
    }
}
