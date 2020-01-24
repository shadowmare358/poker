namespace PokerLibrary
{
    interface IEvaluator
    {
        Card[] Cards { get; set; }
        HandValue HandValues { get; set; }

        Hand EvaluateHand();
    }
}