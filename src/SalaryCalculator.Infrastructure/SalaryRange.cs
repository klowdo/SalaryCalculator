using System;
using SalaryCalculator.Domain;
using SalaryCalculator.Domain.Model;

namespace SalaryCalculator.Infrastructure
{
    public sealed class SalaryRange
    {
        private readonly Salary _high;
        private readonly Salary _low;

        public SalaryRange(Salary low, Salary high)
        {
            _low = low ?? throw new ArgumentNullException(nameof(low));
            _high = high ?? throw new ArgumentNullException(nameof(high));
        }

        public bool IsInRange(Salary salary)
        {
            var inRange = _low.GetAnnual() <= salary.GetAnnual()
                          && _high.GetAnnual() >= salary.GetAnnual();
            return inRange;
        }

        public static SalaryRange Create(Salary low, Salary high)
        {
            return new SalaryRange(low, high);
        }
    }
}