using NUnit.Framework;
using SalaryCalculator.Domain.Model;
using SalaryCalculator.Domain.Services;

namespace SalaryCalculator.Domain.Tests
{
    public class SuperAnnuationCalculator_Test
    {
        [Test]
        public void When_Rate_is_09_Procent_super_of_5004_returns_450()
        {
            var expected = Money.CreateAUD(450);

            var sut = SuperAnnuationCalculator.Create(0.09m);

            var salary = Salary.CrateMontly(Money.CreateAUD(5004));

            var actual = sut.Calculate(salary.GetMonthly());

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}