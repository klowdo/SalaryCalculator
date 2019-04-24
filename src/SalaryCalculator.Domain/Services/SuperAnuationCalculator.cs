using System;
using SalaryCalculator.Domain.Model;

namespace SalaryCalculator.Domain.Services
{
    public class SuperAnnuationCalculator
    {
        private readonly Rate _rate;

        private SuperAnnuationCalculator(Rate rate)
        {
            _rate = rate ?? throw new ArgumentNullException(nameof(rate));
        }

        public Money Calculate(Money salary)
        {
            var super = _rate.GetRateOf(salary);
            return super.RoundOff();
        }

        public static SuperAnnuationCalculator Create(decimal rate)
        {
            return Create(Rate.Create(rate));
        }

        public static SuperAnnuationCalculator Create(Rate rate)
        {
            return new SuperAnnuationCalculator(rate);
        }

        public static Money Calculate(Money salary, Rate rate)
        {
            var calculator = Create(rate);
            return calculator.Calculate(salary);
        }
    }
}