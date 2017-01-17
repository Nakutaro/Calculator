using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class PIOperation
    {
        public string Name { get { return "Exp"; } }
        public object Execute(object[] args)
        {
            return Math.PI;
        }
    }
}
