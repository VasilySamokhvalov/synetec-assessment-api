namespace SynetecAssessmentApi.Domain.Models.Calculation.Requests
{
    public class CalculateBonusRequest
    {
        public int TotalBonusPoolAmount { get; set; }
        public int SelectedEmployeeId { get; set; }
    }
}
