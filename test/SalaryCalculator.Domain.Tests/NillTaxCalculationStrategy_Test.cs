using NUnit.Framework;
using SalaryCalculator.Domain.Model;
using SalaryCalculator.Domain.Services.Tax;

namespace SalaryCalculator.Domain.Tests
{
    public class NillTaxCalculationStrategy_Test
    {
        [TestCase(1)]
        [TestCase(6123)]
        [TestCase(12312315)]
        [TestCase(-110)]
        [TestCase(112315)]
        public void When_Any_Argument_Given_Always_return_Zero(int amount)
        {
            var sut = new NillTaxCalculationStrategy();

            var actual = sut.CalculateMonthlyTax(Salary.CrateMontly(Money.CreateAUD(amount)));

            Assert.Zero(actual);
        }
    }
}