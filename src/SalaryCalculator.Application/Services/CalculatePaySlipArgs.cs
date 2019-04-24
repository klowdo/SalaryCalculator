using SalaryCalculator.Domain;
using SalaryCalculator.Domain.Model;

namespace SalaryCalculator.Application.Services
{
    public class CalculatePaySlipArgs
    {
        public Name EmployeeName;
        public TimeRange PaymentDateRange;
        public Salary Salary;
        public Rate SuperRate;
    }
}