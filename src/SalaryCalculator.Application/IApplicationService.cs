using System.Threading.Tasks;

namespace SalaryCalculator.Application
{
    public interface IApplicationService<in TArgs, TResult>
    {
        Task<TResult> ExecuteAsync(TArgs args);
    }
}