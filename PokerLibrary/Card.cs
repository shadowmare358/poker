namespace PokerLibrary
{
   public class Card : ICard
    {
        public enum Suit
        {
            Hearts,
            Spades,
            Diamonds,
            Clubs
        }

        public enum Value
        {
            Two = 2,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace
        }

        public Value MyValue { get; set; }

        public Suit MySuit { get; set; }
    }
}
