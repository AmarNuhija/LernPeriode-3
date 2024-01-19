using System;

class Program
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int player = 1; // Spieler 1 beginnt

    static int choice; // Benutzereingabe für den Spielzug

    static int flag = 0; // 1: Gewinner gefunden; -1: Unentschieden; 0: Spiel läuft weiter

    static void Main(string[] args)
    {
        do
        {
            Console.Clear(); // Konsolenfenster leeren
            Console.WriteLine("Spieler - " + (player % 2 == 0 ? 2 : 1) + ": Markieren Sie Ihr Feld!");

            Board(); // Spielfeld zeichnen

            // Überprüfung auf gültige Benutzereingabe
            bool validInput = false;
            do
            {
                string input = Console.ReadLine();
                validInput = Int32.TryParse(input, out choice);

                if (!validInput || choice < 1 || choice > 9 || board[choice - 1] == 'X' || board[choice - 1] == 'O')
                {
                    Console.WriteLine("Ungültige Eingabe! Bitte erneut versuchen.");
                    validInput = false;
                }
            } while (!validInput);

            // Setzen des Spielzugs auf das Spielfeld
            if (player % 2 == 0)
                board[choice - 1] = 'O';
            else
                board[choice - 1] = 'X';

            flag = CheckWin(); // Überprüfen, ob es einen Gewinner gibt

            player++; // Wechsel zum nächsten Spieler
        } while (flag != 1 && flag != -1);

        Console.Clear();
        Board(); // Aktuelles Spielfeld anzeigen

        if (flag == 1)
            Console.WriteLine("Spieler " + (player % 2 + 1) + " gewinnt!");
        else
            Console.WriteLine("Unentschieden!");

        Console.ReadLine();
    }

    private static void Board()
    {
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[0], board[1], board[2]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[3], board[4], board[5]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[6], board[7], board[8]);
        Console.WriteLine("     |     |      ");
    }

    private static int CheckWin()
    {
        #region Horizontale Überprüfung

        // Zeilen überprüfen
        for (int i = 0; i < 3; i++)
        {
            if (board[i * 3] == board[i * 3 + 1] && board[i * 3 + 1] == board[i * 3 + 2])
                return 1; // Gewinner gefunden
        }

        #endregion

        #region Vertikale Überprüfung

        // Spalten überprüfen
        for (int i = 0; i < 3; i++)
        {
            if (board[i] == board[i + 3] && board[i + 3] == board[i + 6])
                return 1; // Gewinner gefunden
        }

        #endregion

        #region Diagonale Überprüfung

        // Diagonalen überprüfen
        if (board[0] == board[4] && board[4] == board[8])
            return 1; // Gewinner gefunden
        if (board[2] == board[4] && board[4] == board[6])
            return 1; // Gewinner gefunden

        #endregion

        #region Unentschieden Überprüfung

        // Unentschieden überprüfen
        for (int i = 0; i < 9; i++)
        {
            if (board[i] != 'X' && board[i] != 'O')
                return 0; // Spiel läuft weiter
        }

        #endregion

        return -1; // Unentschieden
    }
}
