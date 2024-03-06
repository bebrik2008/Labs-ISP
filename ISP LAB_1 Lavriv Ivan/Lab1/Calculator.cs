using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP_LAB_1_Lavriv_Ivan.Lab1
{
    class Calculator
    {
        public double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        public double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        public double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        public double Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new ArgumentException("Деление на ноль недопустимо.");
            }

            return num1 / num2;
        }

        public double Modulo(double num1, double num2)
        {
            return num1 % num2;
        }

        public double Sqrt(double num1)
        {
            if (num1 < 0)
            {
                throw new ArgumentException("Невозможно вычислить.");
            }

            return Math.Sqrt(num1);
        }

    }
}
