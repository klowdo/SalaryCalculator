using System;

namespace SalaryCalculator.Domain.Model
{
    public class Salary : IEquatable<Salary>
    {
        private const int MonthsInYear = 12;

        public Salary(Money amount, SalaryStrategy period)
        {
            Amount = amount;
            Period = period;
        }

        public Money Amount { get; }
        public SalaryStrategy Period { get; }

        public bool Equals(Salary other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Amount, other.Amount) && Period == other.Period;
        }

        public Money GetAnnual()
        {
            switch (Period)
            {
                case SalaryStrategy.Monthly:
                    return (Amount * MonthsInYear).RoundOff();
                case SalaryStrategy.Annual:
                    return Amount.RoundOff();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Money GetMonthly()
        {
            switch (Period)
            {
                case SalaryStrategy.Monthly:
                    return Amount.RoundOff();
                case SalaryStrategy.Annual:
                    return (Amount / MonthsInYear).RoundOff();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Money Get(TimeRange timeRange)
        {
            return GetMonthly() * timeRange.Months();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Salary) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Amount != null ? Amount.GetHashCode() : 0) * 397) ^ (int) Period;
            }
        }

        public static Salary CrateAnnual(Money amount)
        {
            return new Salary(amount, SalaryStrategy.Annual);
        }

        public static Salary CrateMontly(Money amount)
        {
            return new Salary(amount, SalaryStrategy.Monthly);
        }

        public override string ToString()
        {
            return $"{Amount} {Period:G}";
        }
    }

    public enum SalaryStrategy
    {
        Monthly,
        Annual
    }
}