using SalaryCalculator.Domain;
using SalaryCalculator.Domain.Model;

namespace SalaryCalculator.Application.Services
{
    public class PaySlipResult
    {
        public Employee Employee;
        public Money IncomeTax;
        public Money NetIncome;
        public TimeRange PaymentDateRange;
        public Money Super;
    }
}