/*
*   Programmiere einen Taschenrechner. Die Eingabe von Rechenoperationen erfolgt über die
*   Kommandozeile, der Taschenrechner sollte die Aneinanderreihung mehrere Operationen
*   unterstützen.
*   Außerdem sollten die folgenden Operationen verfügbar sein:
*   +,-,*,/,%,x^y
*
*   Die Priorität der Operationen wird durch die Operationszeichen bestimmt, es werden
*   aber keine Klammern unterstützt. Die Operanden werden mit einem Leerzeichen voneinander
*   getrennt, also hat eine Eingabe das Format:
*
*   [op1] [operation] [op2]
*
*   Wobei vom Programm erwartet wird, das korrekte Ergebnis zurückzuliefern. Dieser Wert 
*   wird dann als erster Operand verwendet,falls kein anderer explizit eingegeben wird.
*   Der Benutzer wird zwar immer die Leerzeichen setzen, allerdings kann er manchmal im 
*   Eifer des Gefechts die falsche Taste treffen, daher müssen die Operationen und 
*   Operanden geprüft werden.
*
*   Die Operanden sind ganze Zahlen sowohl im positiven als auch negativen Bereich, 
*   bis zu MAX_INT bzw. MIN_INT
*   
*   Die Nutzung von Bibliotheksfunktionen ist bis auf Evaluierungsfunktionen für Strings
*   gestattet.
*   
*   Die Rahmenbedingungen sehen vor dass:
*   1. Das Format der Eingabe immer eingehalten wird:
*       [operand] [operator] [operand] [operator] [operand] ... [operator] [operand]
*   2. Mögliche Operator: ^ (power) % (mod) * (mult) / (div) + (add) - (sub)
*   3. int.Min <= operand <= int.Max || 'a' <= operand <= 'z'
*   4. Reihenfolge: 1.) power 2.) mod 3.) div 4.) mult 5.) sub 6.) add
*   5. Bei der Eingabe von ungültigen Charactern oder einer nicht vollständigen Operation
*   oder bei fehlender Eingabe soll 0 oder eine Fehlermeldung ausgegeben werden, 0 ist in
*   dem Fall der gemerkte Wert für die nächste Operation
*   6. Bei Division durch 0 ist das Ergebnis der Operation 0 oder ein Fehler
*   7. Das Programm soll auf die Eingabe einer Rechenaufgabe warten, das Ergebnis ausgeben
*   und anschließend für weitere Berechnungen zur Verfügung stehen, wobei der Wert des
*   letzten Resultats als Startwert für die nächste Rechnung verwendet wird
*   8. Es gibt insgesamt 120 Punkte zu erreichen:
*   30 Punkte für die Testfälle der Berechnungen, 1P pro Fall.
*   10 Punkte für Codestyle (jeder startet mit 10 und verliert 1 pro Stirnrunzeln beim Code lesen)
*   10 Punkte für das korrekte Handling des Inputs und das Abfangen von Sonderzeichen
*   10 Punkte für die Funktionalität der Weitergabe vom Ergebnis der letzten Berechnung
*   9. Abgabe bis 29.11.2020 23:59 Uhr (an m.weber@training4people.org)
*
*    Folgende Tests werden durchgeführt:
*           0 + 0 = 0
*           2 * 3 = 6
*           16 - 8 = 8
*           5 % 3 = 2
*           16 / 4 = 4
*           16 / 3 = 5,333333333333333
*           2 ^ 3 = 8
*           12 + 10 = 22
*           35 + -13 + 4 = 26
*           2 * -2 = -4
*
*           3 + 5 * 7 = 38
*           2 ^ 5 * 14 / 7 - -16 = 80
*           -465 * 34 / 17 - 11 ^ 2 = -1051
*           214 % 6 * -15 + 5 ^ 3 - 2 ^ -2 = 64,75
*           214 % 6 * -15 + 5 ^ 3 - 2 ^ -2 - 2 ^ 5 * 14 / 7 - -16 = 16,75
*           2 ^ -2 = 0,25
*           2 + 5 * 3 ^ 2 % 2 = 7
*           16 / 3 - -5 = 10,333333333333332
*           77 % 15 * 2 ^ -4 - 11 + -21 = -31,875
*           69 / 420 * 559 - 12 ^ -15 - -77 + 21 ^ 3 = 9429,835714285715
*
*           23 % 21 / 23 * 6 - -3 + -5 * -9,48,52173913043478
*           99 ^ 10 / -14 ^ 21 + 12 = 11,999922791841046
*           213 - 231 + 0 * -1 + 2 ^ 10 = 1006
*           632 / 91 - 17 ^ 2 + 4 * 4 ^ -8 = -282,0548840197888
*           89 ^ -4 * 15 / 7 + 11 * -0 = 3,415334085464277E-08
*           124 ^ 55 * 789 / 3 + 123 * 5 ^ 11 = 3,6153340578486924E+117
*           -17 ^ 6 + 5 - 61 / 13 % 5 = 24137553,666666668
*           Keine Eingabe = 0
*           -99 + 123 ^ 2 - 5 / 3 * 7 + -99 = 14919,333333333334
*           5 / 0 = 0
*
*/