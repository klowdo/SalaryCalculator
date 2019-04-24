using System;
using NUnit.Framework;
using SalaryCalculator.Domain.Model;

namespace SalaryCalculator.Domain.Tests
{
    [TestFixture]
    public class TimeRage_Test
    {
        [Test]
        public void When_Calculating_Months_minumum_1_Month()
        {
            var sut = TimeRange.Create(
                DateTimeOffset.Parse("2019/03/01"),
                DateTimeOffset.Parse("2019/03/31"));

            var expectedMonths = 1;

            Assert.AreEqual(expectedMonths, sut.Months());
        }

        [Test]
        public void When_Calculating_Months_return_Months()
        {
            var sut = TimeRange.Create(
                DateTimeOffset.Parse("2019/03/01"),
                DateTimeOffset.Parse("2019/06/30"));

            var expectedMonths = 4;

            Assert.AreEqual(expectedMonths, sut.Months());
        }
    }
}