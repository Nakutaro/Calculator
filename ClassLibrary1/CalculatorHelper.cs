using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorHelper
{
    public class Calculator
    {
        public Calculator(IEnumerable<IOperation> opers)
        {
            operations = opers;
        }
        public Calculator(IOperation[] opers)
        {
            operations = opers;
        }
        private IEnumerable<IOperation> operations { get; set; }

        public object Execute(string name, object[] args)
        {
            var oper = operations.FirstOrDefault(o => o.Name == name);
            if (oper == null)
            {
                return $"Operation\"{name}\"not found";
            }
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
            var x = Convert.ToInt32(args[1]);
            var y = Convert.ToInt32(args[0]);
            return x+y;
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
