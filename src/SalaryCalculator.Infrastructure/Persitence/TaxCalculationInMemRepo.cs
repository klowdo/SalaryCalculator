using System;
using System.Collections.Generic;
using System.Linq;
using SalaryCalculator.Application.Services;
using SalaryCalculator.Domain.Model;
using SalaryCalculator.Domain.Services.Tax;

namespace SalaryCalculator.Infrastructure.Persitence
{
    public class TaxCalculationInMemRepo : ITaxCalculationStrategyRepository
    {
        private readonly IList<TaxLevel> _taxCalculationStrategies = new List<TaxLevel>
        {
            new TaxLevel(CreateRange(0, 18_200), new NillTaxCalculationStrategy()),
            new TaxLevel(CreateRange(18_201, 37_000), Strategy(0, 0, 0.19m)),
            new TaxLevel(CreateRange(37_001, 87_000), Strategy(37_000, 3_572, 0.325m)),
            new TaxLevel(CreateRange(87_001, 180_000), Strategy(87_000, 19_822, 0.37m)),
            new TaxLevel(CreateRange(180_001, int.MaxValue), Strategy(180_000, 54_232, 0.45m))
        };

        public ITaxCalculationStrategy GetStrategy(Salary salary)
        {
            return _taxCalculationStrategies.SingleOrDefault(x => x.IsSatisfied(salary))?.CalculationStrategy
                   ?? throw new ArgumentException(nameof(salary));
        }

        private static SalaryRange CreateRange(int lower, int upper)
        {
            return SalaryRange.Create(Salary.CrateAnnual(Money.CreateAUD(lower)),
                Salary.CrateAnnual(Money.CreateAUD(upper)));
        }

        private static DefaultTaxCalculationCalculationStrategy Strategy(int fixedDeductAmount, int fixedTax,
            decimal rate)
        {
            return new DefaultTaxCalculationCalculationStrategy(Money.CreateAUD(fixedDeductAmount),
                Money.CreateAUD(fixedTax), Rate.Create(rate));
        }

        public class TaxLevel : ISpecification<Salary>
        {
            private readonly SalaryRange _salaryRange;

            public TaxLevel(SalaryRange salaryRange, ITaxCalculationStrategy calculationStrategy)
            {
                CalculationStrategy = calculationStrategy;
                _salaryRange = salaryRange;
            }

            public ITaxCalculationStrategy CalculationStrategy { get; }

            public bool IsSatisfied(Salary input)
            {
                return _salaryRange.IsInRange(input);
            }
        }
    }
}