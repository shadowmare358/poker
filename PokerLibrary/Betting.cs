using System;

namespace PokerLibrary
{
    public class Betting : IBetting
    {
        public double PlayerWallet { get; set; }
        public double ComputerWallet { get; set; }
        public int Pot { get; set; }
        public int Bet { get; set; }

        public Betting()
        {
            PlayerWallet = 100;
            ComputerWallet = 100;
            DescribeGameState();
        }
        public void ComputerWin()
        {
            Console.WriteLine("COMPUTER WINS!\n");
            PlayerWallet -= Pot;
            ComputerWallet += Pot;
            DescribeGameState();
        }
        public void PlayerWin()
        {
            Console.WriteLine("PLAYER WINS!\n");
            ComputerWallet -= Pot;
            PlayerWallet += Pot;
            DescribeGameState();
        }
        public void Draw()
        {
            Console.WriteLine("IT'S A DRAW!\n");
            ComputerWallet += Bet;
            PlayerWallet += Bet;
            DescribeGameState();
        }
        private void DescribeGameState()
        {
            if (CheckSolvency())
            {
                Console.WriteLine("COMPUTER WALLET: " + ComputerWallet);
                Console.WriteLine("PLAYER WALLET: " + PlayerWallet);
            }else{
                Console.WriteLine("NOT ENOUGHT FOUNDS!");
            }
        }

        public bool CheckSolvency()
        {
            if (ComputerWallet <= 0 || PlayerWallet <= 0){
                ComputerWallet = 0;
                PlayerWallet = 0;
                return false;
            }else{
                return true;
            }
        }
    }
}
