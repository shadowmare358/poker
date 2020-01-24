namespace PokerLibrary
{
    public interface IDeck
    {
        Card[] GetDeck { get; }

        void DeckSetup();
    }
}