using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelSystem.Core.Specifications
{
    public class BasePagedSpecification<T> : Specification<T> where T : class
    {
        public BasePagedSpecification(int offset, int limit)
        {
            Query.Skip(offset)
                .Take(limit);
        }
    }
}
