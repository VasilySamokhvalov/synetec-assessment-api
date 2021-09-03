using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Domain.Models.Calculation.Requests;
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
            var result = await _bonusPoolService.GetEmployeesAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CalculateBonus([FromBody] CalculateBonusRequest request)
        {
            var result = await _bonusPoolService.CalculateAsync(request);
            return Ok(result);
        }
    }
}
