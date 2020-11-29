using System;
using System.Linq;

namespace Taschenrechner
{
    class Program
    {
        public static string zwischensumme = " ";

        static void Main(string[] args)
        {
            bool auswahl = true;

            Console.WriteLine("Willkommen zum Superdupertaschenrechner. Bitte gib deine gewünschte Rechnung ein.");
            string eingabe = Console.ReadLine();
            if (String.IsNullOrEmpty(eingabe))
            {

                Console.WriteLine(0);
                return;

            }

            WeitereBerechnungen(eingabe);

            Console.WriteLine("Möchtest du weiterrechnen ? Drücke j für Ja und n für Nein");

            while (auswahl)
            {
                string weitereEingabe = Console.ReadLine().ToLower();
                if (weitereEingabe == "j")
                {
                    WeitereBerechnungen(Console.ReadLine());
                    Console.WriteLine("Möchtest du weiterrechnen ? Drücke j für Ja und n für Nein");
                }
                else if (weitereEingabe == "n")
                {
                    auswahl = false;
                    Console.WriteLine("Auf Wiedersehen.");
                }
                else
                {
                    Console.WriteLine("Bitte nur j oder n eingeben");
                }
            }

        }

        //Hier wird bei der Eingabe geprüft ob es eine komplett neue Rechnung ist oder ob mit der bestehenden Zwischensumme weitergerechnet werden soll
        static string WeitereBerechnungen(string eingabe)
        {
            char[] weiterrechnen = eingabe.ToCharArray();
            char[] operators = new char[] { '+', '-', '*', '/', '%', '^' };
            char[] ziffern = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            try
            {
                if (Char.IsDigit(weiterrechnen[0]) || (Char.IsDigit(weiterrechnen[1]) && weiterrechnen[0] == '-'))
                {
                    zwischensumme = Convert.ToString(Wandler.Umwandlung(eingabe));
                    Console.WriteLine($"Dein Ergebnis ist {zwischensumme}");
                }

                else if (operators.Contains(weiterrechnen[0]))
                {
                    eingabe = zwischensumme + " " + eingabe;
                    Console.WriteLine(eingabe);
                    zwischensumme = Convert.ToString(Wandler.Umwandlung(eingabe));
                    Console.WriteLine($"Dein Ergebnis ist {zwischensumme}");
                }
                else if (String.IsNullOrEmpty(eingabe))
                {
                    return zwischensumme = "0";
                }

                else
                {                   
                    zwischensumme = "0";
                    return "Ungültige Eingabe";
                }

            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Ungültige Eingabe");
            }
            return zwischensumme;
        }

    }
}

