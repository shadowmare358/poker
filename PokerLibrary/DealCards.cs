using System;
namespace PokerLibrary
{
   public class DealCards : Deck, IDealCards
    {
        private readonly Card[] FlopHand;

        public Card[] FirstComputerHand;
        public Card[] FirstPlayerHand;

        private readonly Betting _bet;
        private readonly Players _players;
        public bool GameOff { get; set; }
        public DealCards()
        {
            GameOff = false;
            _players = new Players();
            _bet = new Betting();
            Console.WriteLine("How much do you want to bet?");
            bool correctValue;
            do {
                var bet = Console.ReadLine();
                if (int.TryParse(bet, out _))
                {
                    _bet.Pot = Convert.ToInt32(bet);
                    if (_bet.Pot > 100)
                    {
                        Console.WriteLine("You got not enought founds!");
                        Console.WriteLine("Please pass value <= 100");
                        correctValue = false;
                    }
                    else {
                        correctValue = true;
                    }
                }else {
                    correctValue = false;
                    Console.WriteLine("Please pass integer value");
                }
            } while (correctValue != true);
            FlopHand = new Card[5];
        }
        public void Deal()
        {
            DeckSetup();
            GetHand();
            _players.SortCards();
            Console.Clear();
            EvaluateHands();

        }
        public void GetHand()
        {
            for (int i = 0; i < 2; i++)
                _players.PlayerHand[i] = GetDeck[i];
            for (int i = 2; i < 4; i++)
                _players.ComputerHand[i - 2] = GetDeck[i];
            for (int i = 4; i < 9; i++)
                FlopHand[i - 4] = GetDeck[i];

            FirstPlayerHand = _players.PlayerHand;
            FirstComputerHand = _players.ComputerHand;
            //2 player cards plus 5 flop cards
            FlopHand.CopyTo(_players.PlayerHand, 2);
            FlopHand.CopyTo(_players.ComputerHand, 2);
        }

        public void EvaluateHands()
        {
            //Pre-flop evaluation
            Evaluator firstPlayerHandEvaluator = new Evaluator(FirstPlayerHand);
            Evaluator firstComputerHandEvaluator = new Evaluator(FirstComputerHand);

            Evaluator playerHandEvaluator = new Evaluator(_players.SortedPlayerHand);
            Evaluator computerHandEvaluator = new Evaluator(_players.SortedComputerHand);

            Hand playerHand = playerHandEvaluator.EvaluateHand();
            Hand computerHand = computerHandEvaluator.EvaluateHand();

            Console.WriteLine("\nPLAYERS HAND: " + playerHand);
            Console.WriteLine("\nCOMPUTERS HAND: " + computerHand + "\n");


            if (playerHand > computerHand)
            {
                _bet.PlayerWin();
            }
            else if (playerHand < computerHand)
            {
                _bet.ComputerWin();
            }
            else
            {
                if (playerHandEvaluator.HandValues.Total > computerHandEvaluator.HandValues.Total)
                {
                    _bet.PlayerWin();
                }
                else if (playerHandEvaluator.HandValues.Total < computerHandEvaluator.HandValues.Total)
                {
                    _bet.ComputerWin();
                }
                else if (firstPlayerHandEvaluator.HandValues.HighCard > firstComputerHandEvaluator.HandValues.HighCard)
                {
                    _bet.PlayerWin();
                }
                else if (firstPlayerHandEvaluator.HandValues.HighCard < firstComputerHandEvaluator.HandValues.HighCard)
                {
                    _bet.ComputerWin();
                }
                else if (firstPlayerHandEvaluator.HandValues.SecondHighCard > firstComputerHandEvaluator.HandValues.SecondHighCard)
                {
                    _bet.PlayerWin();
                }
                else if (firstPlayerHandEvaluator.HandValues.SecondHighCard < firstComputerHandEvaluator.HandValues.SecondHighCard)
                {
                    _bet.ComputerWin();
                }
                else
                {
                    _bet.Draw();
                }
            }
            if (!_bet.CheckSolvency())
            {
                GameOff = true;
            }
        }
    }
}
