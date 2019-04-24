using SalaryCalculator.Domain;
using SalaryCalculator.Domain.Model;
using SalaryCalculator.Domain.Services.Tax;

namespace SalaryCalculator.Application.Services
{
    public interface ITaxCalculationStrategyRepository
    {
        ITaxCalculationStrategy GetStrategy(Salary salary);
    }
}