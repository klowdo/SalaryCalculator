using System;

namespace SalaryCalculator.Domain.Model
{
    public class Employee : Entity<Guid>
    {
        private readonly Name _name;
        private readonly Salary _salary;

        public Employee() : base(Guid.NewGuid())
        {
        }

        public Employee(Guid id, Name name, Salary salary) : base(id)
        {
            _name = name;
            _salary = salary;
        }

        public Name GetName() => _name;

        public Salary GetSalary() => _salary;
    }
}