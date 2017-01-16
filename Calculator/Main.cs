using CalculatorHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator(new CalculatorHelper.IOperation[] {
                new CalculatorHelper.SumOperation(),
                new CalculatorHelper.MultiplicationOperation(),
                new CalculatorHelper.CubeOperation(),
                new CalculatorHelper.ExpOperation()
                });

            var Sum = calc.Execute("Sum", new object[] { 1, 2 });
            var Multiplication = calc.Execute("Multiplication", new object[] { 3, 4 });
            var Cube = calc.Execute("Cube", new object[] { 6 });
            var Exp = calc.Execute("Exp", new object[] { null });
            Console.WriteLine($"result Sum = {Sum}");
            Console.WriteLine($"result Multiplication = {Multiplication}");
            Console.WriteLine($"result Cube = {Cube}");
            Console.WriteLine($"result Exp = {Exp}");
            Console.ReadKey();
        }
    }
}