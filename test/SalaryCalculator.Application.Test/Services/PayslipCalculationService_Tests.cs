using System;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;
using SalaryCalculator.Application.Services;
using SalaryCalculator.Domain;
using SalaryCalculator.Domain.Model;

namespace SalaryCalculator.Application.Test
{
    public class PayslipCalculationService_Tests
    {
        private readonly Name _employeeName = Name.Create("John", "Smith");
        private readonly Salary _employeeSalary = Salary.CrateAnnual(Money.CreateAUD(200));
        private readonly Money _expectedTax = Money.CreateAUD(30);

        private readonly TimeRange _timeRange = TimeRange.Create(
            DateTimeOffset.Parse("2019/03/01"),
            DateTimeOffset.Parse("2019/04/30"));

        private PaySlipResult Actual;

        [SetUp]
        public async Task SetUp()
        {
            var args = new CalculatePaySlipArgs
            {
                EmployeeName = _employeeName,
                Salary = _employeeSalary,
                SuperRate = Rate.Create(0.5m),
                PaymentDateRange = _timeRange
            };
            var calculator = A.Fake<ITaxCalculator>();
            A.CallTo(() => calculator.CalculateTax(args.Salary, _timeRange))
                .Returns(_expectedTax);
            var sut = CreateSut(calculator);

            Actual = await sut.ExecuteAsync(args);
        }

        [Test]
        public void When_valid_Arguments_return_Correct_IncomeTax()
        {
            Assert.That(Actual.IncomeTax, Is.EqualTo(_expectedTax));
        }

        [Test]
        public void When_valid_Arguments_return_Correct_EmployeeName()
        {
            Assert.That(Actual.Employee.GetName(), Is.EqualTo(_employeeName));
        }

        [Test]
        public void When_valid_Arguments_return_Correct_Salary()
        {
            Assert.That(Actual.Employee.GetSalary(), Is.EqualTo(_employeeSalary));
        }

        [Test]
        public void When_valid_Arguments_return_Correct_TimeRange()
        {
            Assert.That(Actual.PaymentDateRange, Is.EqualTo(_timeRange));
        }

        [Test]
        public void When_valid_Arguments_return_Correct_NetIncome()
        {
            var netIncome = NetIncomeCalculator.Calculate(_employeeSalary.Get(_timeRange), _expectedTax);
            Assert.That(Actual.Employee.GetSalary(), Is.EqualTo(_employeeSalary));
        }

        private PaySlipCalculationService CreateSut(ITaxCalculator taxCalculator = null)
        {
            return new PaySlipCalculationService(
                taxCalculator ?? A.Fake<ITaxCalculator>()
            );
        }
    }
}