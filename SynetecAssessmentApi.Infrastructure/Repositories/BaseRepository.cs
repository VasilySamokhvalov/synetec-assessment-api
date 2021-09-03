using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Domain.Entities;
using SynetecAssessmentApi.Domain.Repositories;

namespace SynetecAssessmentApi.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        public AppDbContext _applicationDbContext;

        protected DbSet<TEntity> _dbSet;

        public BaseRepository(AppDbContext applicationDbContext)
        {
            var dbContextOptionBuilder = new DbContextOptionsBuilder<AppDbContext>();
            dbContextOptionBuilder.UseInMemoryDatabase(databaseName: "HrDb");

            _applicationDbContext = new AppDbContext(dbContextOptionBuilder.Options);
            _dbSet = _applicationDbContext.Set<TEntity>();
        }
    }
}
