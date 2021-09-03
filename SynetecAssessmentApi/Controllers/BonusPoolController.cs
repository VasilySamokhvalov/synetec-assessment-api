using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Domain.Services.Interfaces;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    public class BonusPoolController : Controller
    {
        private readonly IBonusPoolService _bonusPoolService;

        public BonusPoolController(IBonusPoolService bonusPoolService)
        {
            _bonusPoolService = bonusPoolService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _bonusPoolService.GetEmployeesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CalculateBonus([FromBody] CalculateBonusDto request)
        {
            return Ok(await bonusPoolService.CalculateAsync(
                request.TotalBonusPoolAmount,
                request.SelectedEmployeeId));
        }
    }
}
