namespace PokerLibrary
{
    public interface IDealCards
    {
        bool GameOff { get; set; }

        void Deal();
        void EvaluateHands();
        void GetHand();
    }
}