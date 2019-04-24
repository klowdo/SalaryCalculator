using SalaryCalculator.Domain.Model;

namespace SalaryCalculator.Application.Services
{
    public class NetIncomeCalculator
    {
        public static Money Calculate(Money salary, Money tax)
        {
            return salary - tax;
        }
    }
}