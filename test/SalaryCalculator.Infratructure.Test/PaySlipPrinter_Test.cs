using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;
using SalaryCalculator.Application.Services;
using SalaryCalculator.Domain;
using SalaryCalculator.Domain.Model;
using SalaryCalculator.Infrastructure;
using SalaryCalculator.Infrastructure.Presentation;

namespace Tests
{
    public class PaySlipPrinter_Test
    {
        [Test]
        public async Task Given_Exercise_Output_Expected_Result_To_Console()
        {
//         Input (first name, last name, annual salary, super rate (%), payment start date):
//         David,Rudd,60050,9%,01 March – 31 March
//         Ryan,Chen,120000,10%,01 March – 31 March


//         Output (name, pay period, gross income, income tax, net income, super):
//         David Rudd,01 March – 31 March,5004,922,4082,450
//         Ryan Chen,01 March – 31 March,10000,2669,7331,1000

            var fakeConsole = A.Fake<IConsoleOutput>();
            var sut = new ConsolePayslipPrinter(fakeConsole);
            var payslips = new List<PaySlipResult>
            {
                new PaySlipResult
                {
                    Employee = new Employee(Guid.NewGuid(), Name.Create("David", "Rudd"),
                        Salary.CrateAnnual(Money.CreateAUD(60_050))),
                    IncomeTax = Money.CreateAUD(922),
                    NetIncome = Money.CreateAUD(4082),
                    Super = Money.CreateAUD(450),
                    PaymentDateRange = TimeRange.Create(DateTimeOffset.Parse("2019/03/01"),
                        DateTimeOffset.Parse("2019/03/31"))
                },
                new PaySlipResult
                {
                    Employee = new Employee(Guid.NewGuid(), Name.Create("Ryan", "Chen"),
                        Salary.CrateAnnual(Money.CreateAUD(120_000))),
                    IncomeTax = Money.CreateAUD(2669),
                    NetIncome = Money.CreateAUD(7331),
                    Super = Money.CreateAUD(1000),
                    PaymentDateRange = TimeRange.Create(DateTimeOffset.Parse("2019/03/01"),
                        DateTimeOffset.Parse("2019/03/31"))
                }
            };

            await sut.Print(payslips);

            var expected = "David Rudd,01 March – 31 March,5004,922,4082,450" + Environment.NewLine +
                           "Ryan Chen,01 March – 31 March,10000,2669,7331,1000";

            A.CallTo(fakeConsole)
                .WhenArgumentsMatch(x => x.Get<string>(0).Trim() == expected.Trim())
                .MustHaveHappenedOnceExactly();
        }
    }
}