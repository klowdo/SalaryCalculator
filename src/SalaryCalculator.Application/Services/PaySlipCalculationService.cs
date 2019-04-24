using System;
using System.Threading.Tasks;
using SalaryCalculator.Domain.Model;
using SalaryCalculator.Domain.Services;

namespace SalaryCalculator.Application.Services
{
    public class PaySlipCalculationService : IApplicationService<CalculatePaySlipArgs, PaySlipResult>
    {
        private readonly ITaxCalculator _taxCalculator;

        public PaySlipCalculationService(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator ?? throw new ArgumentNullException(nameof(taxCalculator));
        }

        public Task<PaySlipResult> ExecuteAsync(CalculatePaySlipArgs args)
        {
            ValidateArgs(args);

            var tax = _taxCalculator.CalculateTax(args.Salary, args.PaymentDateRange);
            var netIncome = NetIncomeCalculator.Calculate(args.Salary.Get(args.PaymentDateRange), tax);
            var super = SuperAnnuationCalculator.Calculate(args.Salary.Get(args.PaymentDateRange), args.SuperRate);
           
            var result = new PaySlipResult
            {
                Employee = new Employee(
                    Guid.NewGuid(),
                    args.EmployeeName,
                    args.Salary
                ),
                PaymentDateRange = args.PaymentDateRange,
                IncomeTax = tax,
                NetIncome = netIncome,
                Super = super
            };

            return Task.FromResult(result);
        }

        private static void ValidateArgs(CalculatePaySlipArgs args)
        {
            if (args.EmployeeName is null) throw new ArgumentNullException(nameof(args.EmployeeName));
            if (args.Salary is null) throw new ArgumentNullException(nameof(args.Salary));
            if (args.SuperRate is null) throw new ArgumentNullException(nameof(args.SuperRate));
            if (args.PaymentDateRange is null) throw new ArgumentNullException(nameof(args.PaymentDateRange));
        }
    }
}