using SalaryCalculator.Domain.Model;

namespace SalaryCalculator.Domain.Services.Tax
{
    public interface ITaxCalculationStrategy
    {
        Money CalculateMonthlyTax(Salary salary);
    }
}