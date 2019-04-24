using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SalaryCalculator.Application;

namespace SalaryCalculator.Infrastructure
{
    public class ApplicationServiceDebugOutputDecorator< TArgs, TResult>: IApplicationService< TArgs, TResult>
    {
        private readonly IApplicationService<TArgs, TResult> _inner;

        public ApplicationServiceDebugOutputDecorator(IApplicationService< TArgs, TResult> inner)
        {
            _inner = inner;
        }
        public async Task<TResult> ExecuteAsync(TArgs args)
        {
            Console.WriteLine();
            Console.WriteLine("=========================");
            Console.WriteLine("Processing args:");
            Console.WriteLine(args.ToString());
            Console.WriteLine($"On Service {_inner.GetType().Name}");
            var sw = new Stopwatch();
            sw.Start();
            var result =  await _inner.ExecuteAsync(args);
            sw.Stop();
            Console.WriteLine($"Took: {sw.Elapsed}");
            Console.WriteLine("=========================");
            Console.WriteLine();

            return result;
        }
    }
}