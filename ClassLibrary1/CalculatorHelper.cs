using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorHelper
{
    public class Calculator
    {
        public Calculator(IOperation[] opers)
        {
            operations = opers;
        }
        private IOperation[] operations { get; set; }

        public object Execute(string name, object[] args)
        {
            var oper = operations.FirstOrDefault(o => o.Name == name);
            return oper.Execute(args);
        }
    }

    public interface IOperation //только описание мтодов в intarface
    {
        string Name { get; }
        object Execute(object[] args);
    }

    public class SumOperation : IOperation//операция суммирования аргументов
    {
        public string Name { get { return "Sum"; } }
        public object Execute(object[] args)
        {
            return (int)args[0] + (int)args[1];
        }
    }

    public class MultiplicationOperation : IOperation//операция перемножения аргументов
    {
        public string Name { get { return "Multiplication"; } }
        public object Execute(object[] args)
        {
            return (int)args[0] * (int)args[1];
        }
    }

    public class CubeOperation : IOperation//аргумент в кубе
    {
        public string Name { get { return "Cube"; } }
        public object Execute(object[] args)
        {
            return (int)args[0] * (int)args[0]* (int)args[0];
        }
    }

    public class ExpOperation : IOperation//экспонента в n-ой степени, преобразованная в целое число
    {
        public string Name { get { return "Exp"; } }
        public object Execute(object[] args)
        {
            int n = 10;
            return (int)(Math.Exp(n));
        }
    }
}
