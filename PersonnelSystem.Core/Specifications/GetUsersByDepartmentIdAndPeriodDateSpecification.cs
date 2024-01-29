using Ardalis.Specification;
using PersonnelSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelSystem.Core.Specifications
{
    public class GetUsersByDepartmentIdAndPeriodDateSpecification : BasePagedSpecification<Employee>
    {
        public GetUsersByDepartmentIdAndPeriodDateSpecification(
            Guid departmentId,
            DateTime startDate,
            DateTime endDate,
            int offset,
            int limit) : base(offset, limit)
        {
            Query.Where(x => 
            x.DepartmentId == departmentId &&
            x.DateOfEmployment <= startDate &&
            x.DateOfEmployment >= endDate);
        }
    }
}
