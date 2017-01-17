using CalculatorHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            //var calc = new Calculator(new CalculatorHelper.IOperation[] {
            //    new CalculatorHelper.SumOperation(),
            //    new CalculatorHelper.MultiplicationOperation(),
            //    new CalculatorHelper.CubeOperation(),
            //    new CalculatorHelper.ExpOperation()
            //    });

            //var Sum = calc.Execute("Sum", new object[] { 1, 2 });
            //var Multiplication = calc.Execute("Multiplication", new object[] { 3, 4 });
            //var Cube = calc.Execute("Cube", new object[] { 6 });
            //var Exp = calc.Execute("Exp", new object[] { null });
            //Console.WriteLine($"result Sum = {Sum}");
            //Console.WriteLine($"result Multiplication = {Multiplication}");
            //Console.WriteLine($"result Cube = {Cube}");
            //Console.WriteLine($"result Exp = {Exp}");
            if (!args.Any())
            {
                Console.WriteLine("Не все аргументы введены");
                Console.ReadKey();
                return;
            }
            var operations = new List<IOperation>();
            #region Получение всех операций
            //найти .dll и .exe файлы в текущей директории

            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.dll").
                Union(Directory.GetFiles(Environment.CurrentDirectory, "*.exe"));
            //загрузить файлы
            foreach(var file in files)
            {
                var assembly = Assembly.LoadFile(file);
                var types = assembly.GetTypes();



                foreach (var type in types)
                {
                    var interfaces = type.GetInterfaces();
                    if (interfaces.Contains(typeof(IOperation)))
                    {
                        Console.WriteLine(type.Name);
                        //создание экземпляра класса и приводим к нужному интерфейсу
                        var oper = Activator.CreateInstance(type) as IOperation;
                        if (oper != null)
                        {
                            operations.Add(oper);
                        }

                    }

                }
                //Console.WriteLine(file);
            }
            #endregion
            //найти реализацию интерфейса IOperation
            //создать экземпляр класса 
            //все экземпляры передаем в CalculatorHelper

            var calc = new CalculatorHelper.Calculator(operations);

            var activeoper = args[0];
            var parameters = args.Skip(1).ToArray();

            var result = calc.Execute(activeoper, parameters);
            Console.WriteLine($"result = {result}");


            Console.ReadKey();
        }
    }
}