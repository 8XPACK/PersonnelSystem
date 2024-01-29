using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using PersonnelSystem.Core.Abstract;
using PersonnelSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelSystem.Infrastructure.Repository
{
    public class EFRepository<TEntity> : RepositoryBase<TEntity>, IRepository<TEntity>
    where TEntity : class
    {
        private readonly PersonnelSystemContext _dbContext;

        public EFRepository(PersonnelSystemContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public EFRepository(
            PersonnelSystemContext dbContext,
            ISpecificationEvaluator specificationEvaluator)
            : base(dbContext, specificationEvaluator)
        {
        }

        public async Task<TEntity?> GetByCompositeIdAsync(params object[] keyValues)
        {
            return await _dbContext.Set<TEntity>().FindAsync(keyValues);
        }
    }
}
