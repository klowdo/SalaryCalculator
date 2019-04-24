using NUnit.Framework;
using SalaryCalculator.Application.Services;
using SalaryCalculator.Domain;
using SalaryCalculator.Domain.Model;

namespace SalaryCalculator.Application.Test
{
    [TestFixture]
    public class NetIncomeCalculatorTest
    {
        [Test]
        public void Subtract_Tax_from_Income_to_get_expected_netIncome()
        {
            var salary = Money.CreateAUD(1000);
            var tax = Money.CreateAUD(500);

            var result = NetIncomeCalculator.Calculate(salary, tax);
            
            Assert.That(result, Is.EqualTo(Money.CreateAUD(500)));
        }
    }
}