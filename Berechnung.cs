using System;
using System.Linq;

namespace Taschenrechner
{
    //Diese Funktion berechnet aus den gegebenen Werten und dem Operanten das Ergebnis
    class Rechnen
    {
        public static double Berechnung(double a, double b, char c)
        {
            double sum = 0;
            switch (c)
            {
                case '+':
                    sum = a + b;
                    break;
                case '-':
                    sum = a - b;
                    break;
                case '*':
                    sum = a * b;
                    break;
                case '/':
                    sum = a / b;
                    break;
                case '^':
                    sum = Convert.ToDouble(Math.Pow(a, b));
                    break;
                case '%':
                    sum = a % b;
                    break;
                default:
                    sum = 0;
                    break;
            }
            return sum;

        }
    }
}