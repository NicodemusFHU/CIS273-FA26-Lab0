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

        switch (card1.Type)
        {

            case CardType.Number:
                if (card2.Type == CardType.Number)
                {
                    return card1.Number == card2.Number || card1.Color == card2.Color;
                }
                else if (card2.Type == CardType.Wild || card2.Type == CardType.WildDraw4)
                {
                    // TODO, check current color
                }
                else
                {
                    // SKIP, REVERSE, DRAW2
                    //TODO, check color
                }

                break;


                default:
                    return false;




        }

        return false;
    }
    public override string ToString()
    {
        //TODO handle other card types

        return $"{Color} {Number}";
    }

}