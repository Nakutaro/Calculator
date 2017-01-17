using CalculatorHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewOperation
{
    public class Therma : IOperation
    {
        public string Name
        {
            get
            {
                return "th";
            }
        }
        public object Execute(object[] args)
        {
            return "Therma";
        }
    }
}
