using System;
using FakeItEasy;
using NUnit.Framework;
using SalaryCalculator.Domain.Model;

namespace SalaryCalculator.Domain.Tests
{
    [TestFixture]
    public class Employee_Test
    {
        [Test]
        public void When_Given_Employee_Name_Expect_GetName_Same()
        {
            var name = Name.Create("John", "Smith");
            var sut = new Employee(Guid.NewGuid(), name, A.Dummy<Salary>());
            
            Assert.That(name, Is.EqualTo(sut.GetName()));
        }
        
        [Test]
        public void When_Given_Employee_Salary_Expect_GetSalary_Same()
        {
            var salary = Salary.CrateAnnual(Money.CreateAUD(200));
            var sut = new Employee(Guid.NewGuid(), A.Dummy<Name>(), salary);
            
            Assert.That(salary, Is.EqualTo(sut.GetSalary()));
        }
    }
}