using System;
using FakeItEasy;
using NUnit.Framework;
using SalaryCalculator.Domain;
using SalaryCalculator.Domain.Model;

namespace Tests
{
    [TestFixture]
    public class Salary_Test
    {
        [Test]
        public void When_CreateAnnual_strategy_is_Annual()
        {
            var sut = Salary.CrateAnnual(A.Dummy<Money>());
            Assert.That(sut.Period, Is.EqualTo(SalaryStrategy.Annual));
        }

        [Test]
        public void When_CreateMonthly_strategy_is_Monthly()
        {
            var sut = Salary.CrateMontly(A.Dummy<Money>());
            Assert.That(sut.Period, Is.EqualTo(SalaryStrategy.Monthly));
        }

        [Test]
        public void When_Given_TimeRange_for_2_Months_Calculate_Salary_for_2_Months()
        {
            var expected = Money.CreateAUD(400);
            var sut = Salary.CrateMontly(Money.CreateAUD(200));
            var timeRange = TimeRange.Create(
                DateTimeOffset.Parse("2019/03/01"),
                DateTimeOffset.Parse("2019/04/30"));

            var actual = sut.Get(timeRange);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void When_Salary_created_with_Annual_divide_with_12_to_get_Monthly()
        {
            var expected = Money.CreateAUD(1);

            var sut = Salary.CrateAnnual(Money.CreateAUD(12));

            var actual = sut.GetMonthly();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void When_Salary_created_with_Monthly_multiply_with_12_to_get_Annual()
        {
            var expected = Money.CreateAUD(12);

            var sut = new Salary(Money.CreateAUD(1), SalaryStrategy.Monthly);

            var actual = sut.GetAnnual();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void When_Salary_is_with_decimal_return_rounded_value()
        {
            // 60,050 / 12 = 5,004.16666667 (round down) = 5,004 
            var expected = Money.CreateAUD(5_004);

            var sut = Salary.CrateAnnual(Money.CreateAUD(60_050));

            var actual = sut.GetMonthly();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}