namespace SalaryCalculator.Domain.Services.Tax
{
    public interface ISpecification<in T>
    {
        bool IsSatisfied(T input);
    }
}