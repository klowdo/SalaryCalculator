using NUnit.Framework;
using SalaryCalculator.Domain;
using SalaryCalculator.Domain.Model;
using SalaryCalculator.Infrastructure;

namespace Tests
{
    public class SalaryRange_Test
    {
        private readonly Money _high = Money.CreateAUD(87_000);
        private readonly Money _low = Money.CreateAUD(37_001);

        private static SalaryRange CreateSut()
        {
            return SalaryRange.Create(Salary.CrateAnnual(Money.CreateAUD(37_001)),
                Salary.CrateAnnual(Money.CreateAUD(87_000)));
        }

        [Test]
        public void When_Salary_is_inRange_return_true()
        {
            var sut = CreateSut();
            var salaryInRange = Salary.CrateAnnual(Money.CreateAUD(40_000));

            Assert.IsTrue(sut.IsInRange(salaryInRange));
        }

        [Test]
        public void When_Salary_is_same_as_high_Value_return_true()
        {
            var sut = CreateSut();

            var salaryInRange = Salary.CrateAnnual(_high);

            Assert.IsTrue(sut.IsInRange(salaryInRange));
        }

        [Test]
        public void When_Salary_is_same_as_low_Value_return_true()
        {
            var sut = CreateSut();

            var salaryInRange = Salary.CrateAnnual(_low);

            Assert.IsTrue(sut.IsInRange(salaryInRange));
        }


        [Test]
        public void When_Salary_is_out_of_Range_return_false()
        {
            var sut = CreateSut();

            var salaryOutOfRange = Salary.CrateAnnual(Money.CreateAUD(100_000));

            Assert.False(sut.IsInRange(salaryOutOfRange));

            var salaryOutOfRange2 = Salary.CrateAnnual(Money.CreateAUD(10_000));

            Assert.False(sut.IsInRange(salaryOutOfRange2));
        }
    }
}