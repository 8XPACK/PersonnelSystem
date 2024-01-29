using Ardalis.Specification;
using PersonnelSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelSystem.Core.Specifications
{
    public class GetMainDepartmentsSpecifictaion : BasePagedSpecification<Department>
    {
        public GetMainDepartmentsSpecifictaion(int offset, int limit) : base(offset, limit)
        {
            Query.Where(x => x.ParentId == null)
                .OrderBy(x => x.DateOfCreation);
        }
    }
}
