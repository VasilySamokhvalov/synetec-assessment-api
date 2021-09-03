using SynetecAssessmentApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllWithDepartments();
        Task<Employee> GetByIdWithDepartment(int id);
        Task<int> GetTotalSalary();
    }
}
