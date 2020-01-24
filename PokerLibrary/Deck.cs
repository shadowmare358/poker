using System;
namespace PokerLibrary
{
    public class Deck : Card, IDeck
    {
        const int NumberOfCards = 52;

        public Deck()
        {
            GetDeck = new Card[NumberOfCards];
        }

        public Card[] GetDeck { get; }

        public void DeckSetup()
        {
            int i = 0;
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value v in Enum.GetValues(typeof(Value)))
                {
                    GetDeck[i] = new Card { MySuit = s, MyValue = v };
                    i++;
                }
            }
            Shuffle(10);
        }
        private void Shuffle(int number)
        {
            Random random = new Random();
            Card temp;
            for (int shuffle = 0; shuffle < number; shuffle++)
            {
                for (int i = 0; i < NumberOfCards; i++)
                {
                    int SecondCardIndex = random.Next(13);
                    temp = GetDeck[i];
                    GetDeck[i] = GetDeck[SecondCardIndex];
                    GetDeck[SecondCardIndex] = temp;
                }
            }
        }
    }
}
