using System.Collections.Generic;
using System.Threading.Tasks;
using SalaryCalculator.Application.Services;

namespace SalaryCalculator.Infrastructure.Presentation
{
    public interface IPrintPayslip
    {
        Task Print(IEnumerable<PaySlipResult> paySlips);
    }
}