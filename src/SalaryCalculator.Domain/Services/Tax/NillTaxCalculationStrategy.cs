using SalaryCalculator.Domain.Model;

namespace SalaryCalculator.Domain.Services.Tax
{
    public class NillTaxCalculationStrategy : ITaxCalculationStrategy
    {
        public Money CalculateMonthlyTax(Salary salary)
        {
            return Money.Zero(salary.Amount.CurrencyCode);
        }
    }
}