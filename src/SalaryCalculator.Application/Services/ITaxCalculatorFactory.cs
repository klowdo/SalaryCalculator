using SalaryCalculator.Domain;
using SalaryCalculator.Domain.Model;

namespace SalaryCalculator.Application.Services
{
    public interface ITaxCalculator
    {
        Money CalculateTax(Salary salary, TimeRange timeRange);
    }
}