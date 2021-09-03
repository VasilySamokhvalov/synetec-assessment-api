using SynetecAssessmentApi.Domain.Models.Dtos;

namespace SynetecAssessmentApi.Domain.Models.Calculation
{
    public class CalculateBonusResponse
    {
        public int Amount { get; set; }
        public EmployeeDto Employee { get; set; }
    }
}
