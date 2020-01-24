using System;
using PokerLibrary;

namespace PokerApp
{
    class Program
    {
        private static DealCards _playPoker;
        static void Main(string[] args)
        {
            _playPoker = new DealCards();
            bool Quit = false;

            while (!Quit)
            {
                _playPoker.Deal();
                char selection = ' ';

                while (!selection.Equals('Y') && !selection.Equals('N'))
                {
                    if (_playPoker.GameOff)
                    {
                        Console.WriteLine("Not enought currency in one of players wallets to play!");
                        Console.ReadKey();
                        return;
                    }
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine("Play again? (Y)es or (N)o");
                    var selectedKey = Console.ReadLine().ToUpper();

                    if (char.TryParse(selectedKey, out _))
                    {
                        selection = Convert.ToChar(selectedKey);
                    }
                    if (selection.Equals('Y'))
                        Quit = false;
                    else if (selection.Equals('N'))
                        Quit = true;
                    else
                        Console.WriteLine("Wrong key pressed, please try again");
                }
            }
        }
    }
}
