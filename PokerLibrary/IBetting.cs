namespace PokerLibrary
{
    public interface IBetting
    {
        int Bet { get; set; }
        double ComputerWallet { get; set; }
        double PlayerWallet { get; set; }
        int Pot { get; set; }

        bool CheckSolvency();
        void ComputerWin();
        void Draw();
        void PlayerWin();
    }
}