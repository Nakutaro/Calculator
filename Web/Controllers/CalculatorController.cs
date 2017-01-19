using CalculatorHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult Index()
        {
            ViewData.Model = new OperationModel();
            return View();
        }

        public ActionResult Execute(OperationModel model)
        {
            var calc = new Calculator(new IOperation[] { new SumOperation() });
            var result = calc.Execute(model.Name, model.GetParameters());
            ViewData.Model = $"result={result}";
            return View();
        }
    }
}