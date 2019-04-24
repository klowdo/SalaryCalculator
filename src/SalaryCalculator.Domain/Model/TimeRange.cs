using System;

namespace SalaryCalculator.Domain.Model
{
    public class TimeRange:IEquatable<TimeRange>
    {
        public readonly DateTimeOffset End;
        public readonly DateTimeOffset Start;

        public TimeRange(DateTimeOffset start, DateTimeOffset end)
        {
            Start = start;
            End = end;
        }

        public int Months()
        {
            var approximatelyMonths = End.Subtract(Start).Days / (365.25m / 12m);

            var rounded = Math.Round(approximatelyMonths, 0, MidpointRounding.AwayFromZero);

            return (int) Math.Max(rounded, 1);
        }

        public static TimeRange Create(DateTimeOffset start, DateTimeOffset end)
        {
            return new TimeRange(start, end);
        }

        public bool Equals(TimeRange other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return End.Equals(other.End) && Start.Equals(other.Start);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TimeRange) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (End.GetHashCode() * 397) ^ Start.GetHashCode();
            }
        }
    }
}