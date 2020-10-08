using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Calculator : Form
    {
        private bool isFirst = true;
        private double op1, op2;
        private string operation;
        public Calculator()
        {
            InitializeComponent();

        }

        private void calculator_Load(object sender, EventArgs e)
        {
            this.one.Click += new System.EventHandler(this.InputButtonClick);
            this.two.Click += new System.EventHandler(this.InputButtonClick);
            this.three.Click += new System.EventHandler(this.InputButtonClick);
            this.four.Click += new System.EventHandler(this.InputButtonClick);
            this.five.Click += new System.EventHandler(this.InputButtonClick);
            this.six.Click += new System.EventHandler(this.InputButtonClick);
            this.secen.Click += new System.EventHandler(this.InputButtonClick);
            this.eight.Click += new System.EventHandler(this.InputButtonClick);
            this.nine.Click += new System.EventHandler(this.InputButtonClick);
            this.zero.Click += new System.EventHandler(this.InputButtonClick);
            this.point.Click += new System.EventHandler(this.InputButtonClick);

            this.add.Click += new System.EventHandler(this.OperationButtonClick);
            this.multiply.Click += new System.EventHandler(this.OperationButtonClick);
            this.divide.Click += new System.EventHandler(this.OperationButtonClick);
            this.subtact.Click += new System.EventHandler(this.OperationButtonClick);
            this.equal.Click += new System.EventHandler(this.OperationButtonClick);
            this.sin.Click += new System.EventHandler(this.OperationButtonClick);
            this.cos.Click += new System.EventHandler(this.OperationButtonClick);
            this.tan.Click += new System.EventHandler(this.OperationButtonClick);
        }



        private void InputButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            char ch = button.Text[0];


            if (isFirst)
            {
                isFirst = false;
                    displayWindow.Text = "";
            }

            if (ch == '.')
            {
                if (displayWindow.Text.Equals(""))
                {
                    displayWindow.Text = "0.";
                }
                else
                {
                    displayWindow.Text += ch;
                }
            }

            if ((ch >= '0' && ch <= '9'))
            {
                displayWindow.Text += ch;
            }
        }

        private void OperationButtonClick(object sender, EventArgs e)
        {
            Console.WriteLine();
            double result = 0;
            Button button = (Button)sender;
            if(!button.Text.Equals("="))
                operation = button.Text;
            op2 = op1;
            op1 = double.Parse(displayWindow.Text);
            displayWindow.Text = "";
            switch (operation)
            {
                case "+":
                    result = op1 + op2;
                    break;
                case "-":
                    result = op1 - op2;
                    break;
                case "*":
                    result = op1 * op2;
                    break;
                case "/":
                    result = op1 / op2;
                    break;
                case "%":
                    result = op1 % op2;
                    break;
                case "^":
                    result = Math.Pow(op1,op2);
                    break;
                case "sin":
                    result = Math.Sin(op1);
                    break;
                case "cos":
                    result = Math.Cos(op1);
                    break;
                case "tan":
                    result = Math.Tan(op1);
                    break;
                
            }

            isFirst = true;
            op1 = result;
            displayWindow.Text = result.ToString(CultureInfo.InvariantCulture);
        }
    }
}
