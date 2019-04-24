using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SalaryCalculator.Application.Services;

namespace SalaryCalculator.Infrastructure.Presentation
{
    public class ConsolePayslipPrinter : IPrintPayslip
    {
        private readonly IConsoleOutput _output;

        public ConsolePayslipPrinter(IConsoleOutput output)
        {
            _output = output;
        }

        public Task Print(IEnumerable<PaySlipResult> paySlips)
        {
            var builder = new StringBuilder();
            foreach (var paySlip in paySlips)
                builder.AppendLine($"{paySlip.Employee.GetName()}," +
                                   $"{paySlip.PaymentDateRange.Start:dd MMMM} – {paySlip.PaymentDateRange.End:dd MMMM}," +
                                   $"{paySlip.Employee.GetSalary().GetMonthly().ToStringWithOutCurrency()}," +
                                   $"{paySlip.IncomeTax.ToStringWithOutCurrency()}," +
                                   $"{paySlip.NetIncome.ToStringWithOutCurrency()}," +
                                   $"{paySlip.Super.ToStringWithOutCurrency()}");
            _output.WriteLine(builder.ToString());
            return Task.CompletedTask;
        }
    }
}