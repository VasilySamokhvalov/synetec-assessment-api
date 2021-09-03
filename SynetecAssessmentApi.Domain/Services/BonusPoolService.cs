using SynetecAssessmentApi.Domain.Entities;
using SynetecAssessmentApi.Domain.Models.Calculation;
using SynetecAssessmentApi.Domain.Models.Calculation.Requests;
using SynetecAssessmentApi.Domain.Models.Dtos;
using SynetecAssessmentApi.Domain.Repositories;
using SynetecAssessmentApi.Domain.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Domain.Services
{
    public class BonusPoolService : IBonusPoolService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public BonusPoolService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            IEnumerable<Employee> employees = await _employeeRepository.GetAllWithDepartments();

            List<EmployeeDto> result = new List<EmployeeDto>();

            foreach (var employee in employees)
            {
                result.Add(
                    new EmployeeDto
                    {
                        Fullname = employee.Fullname,
                        JobTitle = employee.JobTitle,
                        Salary = employee.Salary,
                        Department = new DepartmentDto
                        {
                            Title = employee.Department.Title,
                            Description = employee.Department.Description
                        }
                    });
            }

            return result;
        }

        public async Task<CalculateBonusResponse> CalculateAsync(CalculateBonusRequest request)
        {
            if (request.SelectedEmployeeId == 0)
            {
                throw new System.Exception("Please provide valid EmloyeeId");
            }

            //load the details of the selected employee using the Id
            Employee employee = await _employeeRepository.GetByIdWithDepartment(request.SelectedEmployeeId);
            if(employee is null)
            {
                throw new System.Exception("Employee with specified Id#" + request.SelectedEmployeeId +  " was not found!");
            }

            //get the total salary budget for the company
            int totalSalary = await _employeeRepository.GetTotalSalary();

            return new CalculateBonusResponse
            {
                Employee = new EmployeeDto
                {
                    Fullname = employee.Fullname,
                    JobTitle = employee.JobTitle,
                    Salary = employee.Salary,
                    Department = new DepartmentDto
                    {
                        Title = employee.Department.Title,
                        Description = employee.Department.Description
                    }
                },

                Amount = CalculateEmloyeeBonus(request.TotalBonusPoolAmount, totalSalary, employee.Salary)
            };
        }

        private int CalculateEmloyeeBonus(int bonusPoolAmount, int totalSalary, int employeeSalary)
        {
            decimal bonusPercentage = employeeSalary / (decimal)totalSalary;
            int bonusAllocation = (int)(bonusPercentage * bonusPoolAmount);
            return bonusAllocation;
        }
    }
}
