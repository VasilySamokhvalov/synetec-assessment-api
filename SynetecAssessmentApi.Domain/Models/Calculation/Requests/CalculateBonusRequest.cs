namespace SynetecAssessmentApi.Domain.Models.Calculation.Requests
{
    public class CalculateBonusRequest
    {
        public int TotalBonusPoolAmount { get; set; }
        public int SelectedEmployeeId { get; set; }

        public CalculateBonusRequest(int totalBonusPoolAmount, int selectedEmployeeId)
        {
            TotalBonusPoolAmount = totalBonusPoolAmount;
            SelectedEmployeeId = selectedEmployeeId;
        }
    }
}
