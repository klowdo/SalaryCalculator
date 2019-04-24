using SalaryCalculator.Application;
using SalaryCalculator.Application.Services;
using SalaryCalculator.Infrastructure;
using SalaryCalculator.Infrastructure.Persitence;
using SalaryCalculator.Infrastructure.Presentation;
using SimpleInjector;

namespace SalaryCalculator.ConsoleApp
{
    public static class Bootstrapper
    {
        public static void Bootstrap(Container container)
        {
            container.Register<IPrintPayslip, ConsolePayslipPrinter>();
            container.Register<IConsoleOutput, ConsoleOutput>();
            container.Register<ITaxCalculator, TaxCalculator>();
            container.Register<ITaxCalculationStrategyRepository, TaxCalculationInMemRepo>();
            container.Register(typeof(IApplicationService<,>), typeof(IApplicationService<,>).Assembly);
            container.RegisterDecorator(typeof(IApplicationService<,>), typeof(ApplicationServiceDebugOutputDecorator<,>));
        }
    }
}