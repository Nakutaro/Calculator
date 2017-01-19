using CalculatorHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Калькулятор
        /// </summary>
        private CalculatorHelper.Calculator Calc { get; set; }

        private IEnumerable<string> OperationNames { get; set; }
        private void Form1_Load(object sender, EventArgs e)
        {
            var operations = new List<IOperation>();
            #region Получение всех операций
            //найти .dll и .exe файлы в текущей директории

            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.dll").
                Union(Directory.GetFiles(Environment.CurrentDirectory, "*.exe"));
            //загрузить файлы
            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file);
                var types = assembly.GetTypes();



                foreach (var type in types)
                {
                    var interfaces = type.GetInterfaces();
                    if (interfaces.Contains(typeof(IOperation)))
                    {
                        //Console.WriteLine(type.Name);
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

            Calc = new CalculatorHelper.Calculator(operations);
            OperationNames = Calc.GetOperationNames();
            //заполнить комбобокс
            FillComboBox();
        }
        private void FillComboBox()
        {
            this.comboBox1.Items.AddRange(OperationNames.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblResult.Text = comboBox1.Text;
        }
    }
}
