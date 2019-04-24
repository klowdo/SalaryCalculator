using SalaryCalculator.Domain;
using SalaryCalculator.Domain.Model;

namespace SalaryCalculator.Application.Services
{
    public class TaxCalculator : ITaxCalculator
    {
        private readonly ITaxCalculationStrategyRepository _repository;

        public TaxCalculator(ITaxCalculationStrategyRepository repository)
        {
            _repository = repository;
        }

        public Money CalculateTax(Salary salary, TimeRange timeRange)
        {
            var strategy = _repository.GetStrategy(salary);
            return strategy.CalculateMonthlyTax(salary) * timeRange.Months();
        }
    }
}