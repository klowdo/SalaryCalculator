using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalaryCalculator.Application;
using SalaryCalculator.Application.Services;
using SalaryCalculator.Domain.Model;
using SalaryCalculator.Infrastructure.Presentation;
using SimpleInjector;

namespace SalaryCalculator.ConsoleApp
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var container = new Container();
            Bootstrapper.Bootstrap(container);

            var applicationArgs = GetArgs();

            var service = container.GetInstance<IApplicationService<CalculatePaySlipArgs, PaySlipResult>>();
            var printer = container.GetInstance<IPrintPayslip>();


            var results = await Task.WhenAll(applicationArgs.Select(arg => service.ExecuteAsync(arg)));

            await printer.Print(results);

            Console.WriteLine("===================");
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }

        private static IEnumerable<CalculatePaySlipArgs> GetArgs()
        {
            return new List<CalculatePaySlipArgs>
            {
                new CalculatePaySlipArgs
                {
                    EmployeeName = Name.Create("David", "Rudd"),
                    PaymentDateRange = TimeRange.Create(DateTimeOffset.Parse("2019/03/01"),
                        DateTimeOffset.Parse("2019/03/31")),
                    Salary = Salary.CrateAnnual(Money.CreateAUD(60_050)),
                    SuperRate = Rate.Create(0.09m)
                },
                new CalculatePaySlipArgs
                {
                    EmployeeName = Name.Create("Ryan", "Chen"),
                    PaymentDateRange = TimeRange.Create(DateTimeOffset.Parse("2019/03/01"),
                        DateTimeOffset.Parse("2019/03/31")),
                    Salary = Salary.CrateAnnual(Money.CreateAUD(120_000)),
                    SuperRate = Rate.Create(0.1m)
                }
            };
        }
    }
}