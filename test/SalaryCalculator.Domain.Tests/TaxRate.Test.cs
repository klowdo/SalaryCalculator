using System;
using NUnit.Framework;
using SalaryCalculator.Domain;
using SalaryCalculator.Domain.Model;

namespace Tests
{
    public class TaxRate_Test
    {
        [Test]
        public void When_Rate_is_above_maximum_throw_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Rate.Create(2));
        }

        [Test]
        public void When_Rate_is_below_minimum_throw_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Rate.Create(-1));
        }

        [Test]
        public void When_Rate_is_inRange_throw_nothing()
        {
            Assert.That(() => Rate.Create(0.325m), Throws.Nothing);
        }

        [Test]
        public void When_Rate_is_0_point_5_return_1_of_2AUD()
        {
            var expected = Money.CreateAUD(1);

            var money = Money.CreateAUD(2);

            var sut = Rate.Create(0.5m);

            var actual = sut.GetRateOf(money);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}