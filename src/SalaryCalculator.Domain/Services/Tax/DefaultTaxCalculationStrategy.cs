using System;
using SalaryCalculator.Domain.Model;

namespace SalaryCalculator.Domain.Services.Tax
{
    public class DefaultTaxCalculationCalculationStrategy : ITaxCalculationStrategy
    {
        private readonly Money _fixedDeductAmount;
        private readonly Money _fixedTax;
        private readonly int _monthsInYear = 12;
        private readonly Rate _taxRate;

        public DefaultTaxCalculationCalculationStrategy(Money fixedDeductAmount, Money fixedTax, Rate rate)
        {
            _fixedDeductAmount = fixedDeductAmount ?? throw new ArgumentNullException(nameof(fixedDeductAmount));
            _fixedTax = fixedTax ?? throw new ArgumentNullException(nameof(fixedTax));
            _taxRate = rate ?? throw new ArgumentNullException(nameof(rate));
        }

        public Money CalculateMonthlyTax(Salary salary)
        {
            var annualSalary = salary.GetAnnual();
            var salaryAboveDeducted = annualSalary - _fixedDeductAmount;
            var yearlyTax = _taxRate.GetRateOf(salaryAboveDeducted) + _fixedTax;
            var monthlyTax = yearlyTax / _monthsInYear;
            return monthlyTax.RoundOff();
        }
    }
}