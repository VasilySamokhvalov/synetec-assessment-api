
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SynetecAssessmentApi.Domain.Models.Calculation.Requests;
using SynetecAssessmentApi.Domain.Repositories;
using SynetecAssessmentApi.Domain.Services;
using SynetecAssessmentApi.Domain.Services.Interfaces;
using SynetecAssessmentApi.Infrastructure;
using SynetecAssessmentApi.Infrastructure.Helpers;
using SynetecAssessmentApi.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SynetecAssessementApi.Tests
{
    public class BonusPoolTests
    {
        private readonly IBonusPoolService _bonusPoolService;
        public BonusPoolTests()
        {
            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "HrDb"));

            services.AddTransient<IBonusPoolService, BonusPoolService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            var serviceProvider = services.BuildServiceProvider();
            DbContextGenerator.Initialize(serviceProvider);

            _bonusPoolService = serviceProvider.GetService<IBonusPoolService>();
        }

        [Theory]
        [InlineData(1000, 0)]
        [InlineData(1000, 1000)]
        [InlineData(1000, 1)]
        public async Task BonusPoolCalculation(int totalBonusPoolAmount, int selectedEmployeeId)
        {
            //Act
            var result = await _bonusPoolService.CalculateAsync(new CalculateBonusRequest(totalBonusPoolAmount, selectedEmployeeId));;

            //Assert
            Assert.NotNull(result);
        }
    }
}
