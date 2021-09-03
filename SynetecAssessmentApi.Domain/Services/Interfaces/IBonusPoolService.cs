using SynetecAssessmentApi.Domain.Models.Calculation;
using SynetecAssessmentApi.Domain.Models.Calculation.Requests;
using SynetecAssessmentApi.Domain.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Domain.Services.Interfaces
{
    public interface IBonusPoolService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
        Task<CalculateBonusResponse> CalculateAsync(CalculateBonusRequest request);
    }
}
