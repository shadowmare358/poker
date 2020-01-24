namespace PokerLibrary
{
    public interface IPlayers
    {
        Card[] ComputerHand { get; }
        Card[] PlayerHand { get; }
        Card[] SortedComputerHand { get; }
        Card[] SortedPlayerHand { get; }

        void SortCards();
    }
}