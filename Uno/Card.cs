namespace Uno;

public enum CardType
{
    Number, Wild, Draw2, WildDraw4, Skip, Reverse
}

public enum Color
{
    Red, Yellow, Blue, Green, Wild
}

public class Card
{

    public CardType Type { get; set; }
    public Color Color { get; set; }
    public int? Number { get; set; }


    public static bool PlaysOn(Card card1, Card card2, Color? currentColor = null)
    {
        if (card1.Type == CardType.Number)
        {
            return card2.Number == card1.Number || card2.Color == card1.Color || card1.Color == currentColor;
        }
        else if (card1.Type == CardType.Wild || card1.Type == CardType.WildDraw4)
        {
            return true;
        }
        else if (card1.Type == CardType.Skip || card1.Type == CardType.Reverse || card1.Type == CardType.Draw2)
        {
            return card2.Type == card1.Type || card2.Color == card1.Color || card1.Color == currentColor || card2.Type == CardType.Wild || card2.Type == CardType.WildDraw4;
        }
        return false;
    }
    public override string ToString()
    {
        if(Type == CardType.Wild || Type == CardType.Draw2 || Type == CardType.WildDraw4)
        {
            return $"{Type}";
        }
        if(Type == CardType.Skip || Type == CardType.Reverse || Type == CardType.Draw2)
        {
            return $"{Color} {Type}";
        }
        return $"{Color} {Number}";
    }

}