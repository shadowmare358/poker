namespace PokerLibrary
{
    public interface ICard
    {
        Card.Suit MySuit { get; set; }
        Card.Value MyValue { get; set; }
    }
}