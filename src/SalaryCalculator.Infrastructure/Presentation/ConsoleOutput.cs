using System;

namespace SalaryCalculator.Infrastructure.Presentation
{
    public class ConsoleOutput : IConsoleOutput
    {
        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}