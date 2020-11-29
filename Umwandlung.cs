using System;
using System.Linq;

namespace Taschenrechner
{
    class Wandler
    {
        static double ersterWert = 0;
        static double zweiterWert = 0;
        static char operand;
        public static double Umwandlung(string eingabe)
        {

            double ergebnis = Cutter(eingabe);
            return ergebnis;


        }
        //Hier wird der Startwert anhand der korrekten mathematischen Priorisierung errechnet
        public static int Startwert(string[] values)
        {
            int start;
            if (values.Contains("^"))
            {
                start = Array.IndexOf(values, "^");
            }
            else if (values.Contains("%"))
            {
                start = Array.IndexOf(values, "%");
            }
            else if (values.Contains("*") || values.Contains("/"))
            {
                int a = Array.IndexOf(values, "*");
                int b = Array.IndexOf(values, "/");

                //sofern beide Operatoren vorkommen wird der weiter vorne stehende zuerst berechnet
                if (a >= 0 && b >= 0) start = (a < b) ? a : b;
                //kommt nur einer der beiden Operatoren in dem Term vor wird auch nur derjenige genommen, der Index ist nichtvorkommenden wird systemseitig automatisch auf -1 gesetzt
                else start = (a >= 0) ? a : b;
            }
            else
            {
                start = 1;
            }
            return start;

        }

        //Diese Funktion berechnet einzelne Terme in einem Stringarray, Ausgangspunkt ist der übergebene Startwert.
        //Zusätzlich wird hier auf die korrekte Eingabe geguckt
        public static double Terme(string[] values, int start)
        {
            double ergebnis = 0;

            string[] operators = new string[] { "+", "-", "*", "/", "%", "^" };
            for (int i = start - 1; i <= start + 1; i++)
            {
                bool vorhandeneZiffern = Double.TryParse(values[i], out double number);
                bool vorhandeneOperanten = operators.Contains(values[i]);

                if (vorhandeneZiffern && !(vorhandeneOperanten))
                {
                    ersterWert = Convert.ToDouble(values.ElementAt(start - 1));
                    zweiterWert = Convert.ToDouble(values.ElementAt(start + 1));
                }
                else
                {
                    if (vorhandeneOperanten)
                    {
                        operand = Convert.ToChar(values[start]);
                    }
                    else
                    {
                        Console.WriteLine("Deine Eingabe war leider ungültig ");
                    }
                }
                if ((zweiterWert == 0) && (operand == '/')) ergebnis = 0;
                else ergebnis = Rechnen.Berechnung(ersterWert, zweiterWert, operand);

            }

            return ergebnis;

        }

        //Diese rekursive Funktion nimmt einen String entgegen, splittet ihn,ersetzt die Terme durch ihre Zwischensummen
        //und ruft sich solange selbst wieder auf bis der Ausgabestring nur noch aus einem Ergebnis besteht
        public static double Cutter(string eingabe)
        {
            string[] values = eingabe.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int start = Startwert(values);
            double ergebnis = Terme(values, start);


            values[start] = Convert.ToString(ergebnis);
            values[start - 1] = null;
            values[start + 1] = null;
            string s = "";
            foreach (var value in values) s += value + " ";

            if (values.Length > 3)
            {
                return Cutter(s);
            }
            else
            {
                return ergebnis;
            }

        }
    }
}

