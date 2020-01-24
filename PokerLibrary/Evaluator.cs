namespace PokerLibrary
{
    public enum Hand
    {
        HighCard,
        OnePair,
        TwoPairs,
        ThreeKind,
        Straight,
        Flush,
        FullHouse,
        FourKind
    }

    public struct HandValue
    {
        public int Total { get; set; }
        public int HighCard { get; set; }
        public int SecondHighCard { get; set; }
    }

    class Evaluator : Card, IEvaluator
    {
        private int heartsSum;
        private int diamondSum;
        private int clubSum;
        private int spadesSum;
        private readonly Card[] cards;
        private HandValue handValue;

        public Evaluator(Card[] sortedHand)
        {
            heartsSum = 0;
            diamondSum = 0;
            clubSum = 0;
            spadesSum = 0;
            cards = new Card[7];
            Cards = sortedHand;
            handValue = new HandValue();
            if ((int)cards[0].MyValue > (int)cards[1].MyValue){
                handValue.HighCard = (int)cards[0].MyValue;
                handValue.SecondHighCard = (int)cards[1].MyValue;
            }
            else if ((int)cards[1].MyValue > (int)cards[0].MyValue){
                handValue.HighCard = (int)cards[1].MyValue;
                handValue.SecondHighCard = (int)cards[0].MyValue;
            }
        }

        public HandValue HandValues
        {
            get { return handValue; }
            set { handValue = value; }
        }

        public Card[] Cards
        {
            get { return cards; }
            set
            {
                cards[0] = value[0];
                cards[1] = value[1];
                cards[2] = value[2];
                cards[3] = value[3];
                cards[4] = value[4];
                cards[5] = value[5];
                cards[6] = value[6];
            }
        }

        public Hand EvaluateHand()
        {
            getNumberOfSuit();
            if (FourOfKind())
                return Hand.FourKind;
            else if (FullHouse())
                return Hand.FullHouse;
            else if (Flush())
                return Hand.Flush;
            else if (Straight())
                return Hand.Straight;
            else if (ThreeOfKind())
                return Hand.ThreeKind;
            else if (TwoPairs())
                return Hand.TwoPairs;
            else if (OnePair())
                return Hand.OnePair;
            return Hand.HighCard;
        }


        private void getNumberOfSuit()
        {
            foreach (var element in Cards)
            {
                if (element.MySuit == Suit.Hearts)
                    heartsSum++;
                else if (element.MySuit == Suit.Diamonds)
                    diamondSum++;
                else if (element.MySuit == Suit.Clubs)
                    clubSum++;
                else if (element.MySuit == Suit.Spades)
                    spadesSum++;
            }
        }
        private bool OnePair()
        {
            if (cards[6].MyValue == cards[5].MyValue)
            {
                handValue.Total = (int)cards[6].MyValue * 2;
                return true;
            }
            else if (cards[5].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[5].MyValue * 2;
                return true;
            }
            else if (cards[4].MyValue == cards[3].MyValue)
            {
                handValue.Total = (int)cards[4].MyValue * 2;
                return true;
            }
            else if (cards[3].MyValue == cards[2].MyValue)
            {
                handValue.Total = (int)cards[3].MyValue * 2;
                return true;
            }
            else if (cards[2].MyValue == cards[1].MyValue)
            {
                handValue.Total = (int)cards[2].MyValue * 2;
                return true;
            }
            else if (cards[1].MyValue == cards[0].MyValue)
            {
                handValue.Total = (int)cards[1].MyValue * 2;
                return true;
            }
            return false;
        }
        private bool TwoPairs()
        {
            if (cards[6].MyValue == cards[5].MyValue && cards[4].MyValue == cards[3].MyValue)
            {
                handValue.Total = ((int)cards[4].MyValue * 2) + ((int)cards[6].MyValue * 2);
                return true;
            }
            else if (cards[6].MyValue == cards[5].MyValue && cards[3].MyValue == cards[2].MyValue)
            {
                handValue.Total = ((int)cards[3].MyValue * 2) + ((int)cards[6].MyValue * 2);
                return true;
            }
            else if (cards[6].MyValue == cards[5].MyValue && cards[2].MyValue == cards[1].MyValue)
            {
                handValue.Total = ((int)cards[2].MyValue * 2) + ((int)cards[6].MyValue * 2);
                return true;
            }
            else if (cards[6].MyValue == cards[5].MyValue && cards[1].MyValue == cards[0].MyValue)
            {
                handValue.Total = ((int)cards[1].MyValue * 2) + ((int)cards[6].MyValue * 2);
                return true;
            }
            else if (cards[5].MyValue == cards[4].MyValue && cards[3].MyValue == cards[2].MyValue)
            {
                handValue.Total = ((int)cards[3].MyValue * 2) + ((int)cards[5].MyValue * 2);
                return true;
            }
            else if (cards[5].MyValue == cards[4].MyValue && cards[2].MyValue == cards[1].MyValue)
            {
                handValue.Total = ((int)cards[2].MyValue * 2) + ((int)cards[5].MyValue * 2);
                return true;
            }
            else if (cards[5].MyValue == cards[4].MyValue && cards[1].MyValue == cards[0].MyValue)
            {
                handValue.Total = ((int)cards[1].MyValue * 2) + ((int)cards[5].MyValue * 2);
                return true;
            }
            else if (cards[4].MyValue == cards[3].MyValue && cards[2].MyValue == cards[1].MyValue)
            {
                handValue.Total = ((int)cards[2].MyValue * 2) + ((int)cards[4].MyValue * 2);
                return true;
            }
            else if (cards[4].MyValue == cards[3].MyValue && cards[1].MyValue == cards[0].MyValue)
            {
                handValue.Total = ((int)cards[1].MyValue * 2) + ((int)cards[4].MyValue * 2);
                return true;
            }
            else if (cards[3].MyValue == cards[2].MyValue && cards[1].MyValue == cards[0].MyValue)
            {
                handValue.Total = ((int)cards[1].MyValue * 2) + ((int)cards[3].MyValue * 2);
                return true;
            }
            return false;
        }
        private bool ThreeOfKind()
        {
            if (cards[4].MyValue == cards[5].MyValue && cards[4].MyValue == cards[6].MyValue)
            {
                handValue.Total = (int)cards[6].MyValue * 3;
                return true;
            }
            else if (cards[3].MyValue == cards[4].MyValue && cards[3].MyValue == cards[5].MyValue)
            {
                handValue.Total = (int)cards[5].MyValue * 3;
                return true;
            }

            else if (cards[2].MyValue == cards[3].MyValue && cards[2].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[4].MyValue * 3;
                return true;
            }
            else if (cards[1].MyValue == cards[2].MyValue && cards[1].MyValue == cards[3].MyValue)
            {
                handValue.Total = (int)cards[3].MyValue * 3;
                return true;
            }
            else if (cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue)
            {
                handValue.Total = (int)cards[2].MyValue * 3;
                return true;
            }

            return false;
        }
        private bool FourOfKind()
        {
            if (cards[3].MyValue == cards[4].MyValue && cards[3].MyValue == cards[5].MyValue && cards[3].MyValue == cards[6].MyValue)
            {
                handValue.Total = (int)cards[1].MyValue * 4;
                return true;
            }
            else if (cards[2].MyValue == cards[3].MyValue && cards[2].MyValue == cards[4].MyValue && cards[2].MyValue == cards[5].MyValue)
            {
                handValue.Total = (int)cards[2].MyValue * 4;
                return true;
            }
            else if (cards[1].MyValue == cards[2].MyValue && cards[1].MyValue == cards[3].MyValue && cards[1].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[1].MyValue * 4;
                return true;
            }
            else if (cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue && cards[0].MyValue == cards[3].MyValue)
            {
                handValue.Total = (int)cards[0].MyValue * 4;
                return true;
            }

            return false;
        }

        private bool FullHouse()
        {
            if
                ((cards[2].MyValue == cards[3].MyValue && cards[2].MyValue == cards[4].MyValue && cards[5].MyValue == cards[6].MyValue) ||
                (cards[2].MyValue == cards[3].MyValue && cards[4].MyValue == cards[5].MyValue && cards[4].MyValue == cards[6].MyValue))
            {
                handValue.Total = (int)(cards[2].MyValue) + (int)(cards[3].MyValue) + (int)(cards[4].MyValue) +
                    (int)(cards[5].MyValue) + (int)(cards[6].MyValue);
                return true;
            }
            else if
                ((cards[1].MyValue == cards[2].MyValue && cards[1].MyValue == cards[3].MyValue && cards[4].MyValue == cards[5].MyValue) ||
                (cards[1].MyValue == cards[2].MyValue && cards[3].MyValue == cards[4].MyValue && cards[3].MyValue == cards[5].MyValue))
            {
                handValue.Total = (int)(cards[1].MyValue) + (int)(cards[2].MyValue) + (int)(cards[3].MyValue) +
                    (int)(cards[4].MyValue) + (int)(cards[5].MyValue);
                return true;
            }
            else if ((cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue && cards[3].MyValue == cards[4].MyValue) ||
                (cards[0].MyValue == cards[1].MyValue && cards[2].MyValue == cards[3].MyValue && cards[2].MyValue == cards[4].MyValue))
            {
                handValue.Total = (int)(cards[0].MyValue) + (int)(cards[1].MyValue) + (int)(cards[2].MyValue) +
                    (int)(cards[3].MyValue) + (int)(cards[4].MyValue);
                return true;
            }
            return false;
        }

        private bool Flush()
        {
            if (heartsSum == 5 || diamondSum == 5 || clubSum == 5 || spadesSum == 5)
            {
                handValue.Total = (int)cards[6].MyValue;
                return true;
            }

            return false;
        }

        private bool Straight()
        {
            if (cards[2].MyValue + 1 == cards[3].MyValue &&
                cards[3].MyValue + 1 == cards[4].MyValue &&
                cards[4].MyValue + 1 == cards[5].MyValue &&
                cards[5].MyValue + 1 == cards[6].MyValue)
            {
                handValue.Total = (int)cards[6].MyValue;
                return true;
            }

            else if (
                cards[1].MyValue + 1 == cards[2].MyValue &&
                cards[2].MyValue + 1 == cards[3].MyValue &&
                cards[3].MyValue + 1 == cards[4].MyValue &&
                cards[4].MyValue + 1 == cards[5].MyValue)
            {
                handValue.Total = (int)cards[5].MyValue;
                return true;
            }
            else if (
                cards[0].MyValue + 1 == cards[1].MyValue &&
                cards[1].MyValue + 1 == cards[2].MyValue &&
                cards[2].MyValue + 1 == cards[3].MyValue &&
                cards[3].MyValue + 1 == cards[4].MyValue)
            {
                handValue.Total = (int)cards[4].MyValue;
                return true;
            }
            return false;
        }
    }
}
