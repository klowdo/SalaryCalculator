using NUnit.Framework;
using SalaryCalculator.Domain.Model;
using SalaryCalculator.Domain.Services.Tax;

namespace SalaryCalculator.Domain.Tests
{
    public class DefaultTaxCalculationStrategy_Test
    {
        [Test]
        public void Given_Calculation_Input_returns_expected_Amount()
        {
            var salary = Salary.CrateAnnual(Money.CreateAUD(60_050));

            var expected = Money.CreateAUD(922);

            var sut = new ExampleTaxCalculator();

            var actual = sut.CalculateMonthlyTax(salary);

            Assert.That(actual, Is.EqualTo(expected));
        }

        private class ExampleTaxCalculator : DefaultTaxCalculationCalculationStrategy
        {
            //(3,572 + (60,050 - 37,000) x 0.325) / 12 = 921.9375 (round up) = 922 

            private static readonly Money FixedDeductAmount = Money.CreateAUD(37_000);
            private static readonly Money FixedTax = Money.CreateAUD(3_572);
            private static readonly Rate Rate = Rate.Create(0.325m);

            public ExampleTaxCalculator() : base(FixedDeductAmount, FixedTax, Rate)
            {
            }
        }
    }
}