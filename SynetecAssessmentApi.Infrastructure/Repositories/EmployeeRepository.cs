using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Domain.Entities;
using SynetecAssessmentApi.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = applicationDbContext.Set<Employee>();
        }
        public async Task<List<Employee>> GetAllWithDepartments()
        {
            return await _dbSet.Include(e => e.Department).ToListAsync();
        }

        public async Task<Employee> GetByIdWithDepartment(int id)
        {
            return await _dbSet.Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<int> GetTotalSalary()
        {
            return await _dbSet.SumAsync(e => e.Salary);
        }
    }
}
