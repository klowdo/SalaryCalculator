using System;

namespace SalaryCalculator.Domain.Model
{
    public class Name : IEquatable<Name>
    {
        public Name(string firstname, string lastname)
        {
            //Maybe check for minimum length
            Firstname = firstname ?? throw new ArgumentNullException(nameof(firstname));
            Lastname = lastname ?? throw new ArgumentNullException(nameof(lastname));
        }

        public string Firstname { get; }
        public string Lastname { get; }

        public bool Equals(Name other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Firstname, other.Firstname) && string.Equals(Lastname, other.Lastname);
        }

        public override string ToString()
        {
            return $"{Firstname} {Lastname}";
        }

        public static Name Create(string firstname, string lastname)
        {
            return new Name(firstname, lastname);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Name) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Firstname != null ? Firstname.GetHashCode() : 0) * 397) ^
                       (Lastname != null ? Lastname.GetHashCode() : 0);
            }
        }
    }
}