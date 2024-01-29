using Ardalis.Specification;
using PersonnelSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelSystem.Core.Specifications
{
    public class GetChildByParentIdSpecification : BasePagedSpecification<Department>
    {
        public GetChildByParentIdSpecification(int offset, int limit, Guid id) : base(offset,limit)
        {
            Query.Where(x => x.ParentId == id)
                .OrderBy(x => x.DateOfCreation);
        }
    }
}
