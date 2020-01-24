using System.Linq;
namespace PokerLibrary
{
    public class Players : IPlayers
    {
        public Card[] PlayerHand { get; }
        public Card[] SortedPlayerHand { get; }
        public Card[] ComputerHand { get; }
        public Card[] SortedComputerHand { get; }
        public Players()
        {
            PlayerHand = new Card[7];
            SortedPlayerHand = new Card[7];
            ComputerHand = new Card[7];
            SortedComputerHand = new Card[7];
        }

        public void SortCards()
        {
            var computerCards = from hand in ComputerHand
                                orderby hand.MyValue
                                select hand;
            var playerCards = from hand in PlayerHand
                              orderby hand.MyValue
                              select hand;
            int index = 0;

            foreach (var element in playerCards.ToList()){
                SortedPlayerHand[index] = element;
                index++;
            }
            index = 0;
            foreach (var element in computerCards.ToList()){
                SortedComputerHand[index] = element;
                index++;
            }
        }
    }
}
