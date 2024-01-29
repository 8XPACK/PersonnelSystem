using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelSystem.Core.Abstract
{
    public interface IRepository<TEntity> : IRepositoryBase<TEntity>
where TEntity : class
    {
        public Task<TEntity?> GetByCompositeIdAsync(params object[] keyValues);
    }
}
