using System;
using NUnit.Framework;
using SalaryCalculator.Domain;
using SalaryCalculator.Domain.Model;

namespace Tests
{
    [TestFixture]
    public class Name_Test
    {
        [Test]
        public void When_Name_Create_with_firstname_null_throw_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Name.Create(null, "Smith"));
        }

        [Test]
        public void When_Name_Create_with_lastname_null_throw_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Name.Create("John", null));
        }

        [Test]
        public void When_Name_Create_with_valid_arguments_throws_Nothing()
        {
            Assert.That(() => Name.Create("John", "Smith"), Throws.Nothing);
        }

        [Test]
        public void When_Name_with_equal_value_return_True()
        {
            var name1 = Name.Create("John", "Smith");
            var name2 = Name.Create("John", "Smith");
            Assert.True(name1.Equals(name2));
        }
    }
}