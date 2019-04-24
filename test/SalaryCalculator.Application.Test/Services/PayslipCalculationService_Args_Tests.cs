using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;
using SalaryCalculator.Application.Services;
using SalaryCalculator.Domain;
using SalaryCalculator.Domain.Model;

namespace SalaryCalculator.Application.Test
{
    public class PayslipCalculationService_Args_Tests
    {
        private PaySlipCalculationService CreateSut(ITaxCalculator taxCalculator = null)
        {
            return new PaySlipCalculationService(
                taxCalculator ?? A.Fake<ITaxCalculator>()
            );
        }


        [TestCaseSource(nameof(FailingArguments))]
        public async Task When_Argument_is_Null_Throw_ArgumentNullException_With_argumentName(
            (CalculatePaySlipArgs args, string argumentName) input
        )
        {
            var sut = CreateSut();
            var result = Assert.ThrowsAsync<ArgumentNullException>(() => sut.ExecuteAsync(input.args));
            Assert.That(result.ParamName, Is.EqualTo(input.argumentName));
        }

        public static IEnumerable<(CalculatePaySlipArgs args, string argumentName)> FailingArguments()
        {
            yield return (new CalculatePaySlipArgs
            {
                EmployeeName = null
            }, "EmployeeName");
            yield return (new CalculatePaySlipArgs
            {
                EmployeeName = Name.Create("John", "Smith"),
                Salary = null
            }, "Salary");
            yield return (new CalculatePaySlipArgs
            {
                EmployeeName = Name.Create("John", "Smith"),
                Salary = Salary.CrateAnnual(Money.CreateAUD(200)),
                SuperRate = null
            }, "SuperRate");
            yield return (new CalculatePaySlipArgs
            {
                EmployeeName = Name.Create("John", "Smith"),
                Salary = Salary.CrateAnnual(Money.CreateAUD(200)),
                SuperRate = Rate.Create(0.5m),
                PaymentDateRange = null
            }, "PaymentDateRange");
        }
    }
}