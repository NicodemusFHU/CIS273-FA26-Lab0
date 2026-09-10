namespace Uno;

public class Player
{
    public string Name { get; set; }

    public List<Card> Hand { get; set; }

    public bool HasPlayableCard(Card card)
    {
        return false;
    }

    public Card GetFirstPlayableCard(Card card)
    {
        return null;
    }

    public Color MostCommonColor()
    {
        return Color.Wild;
    }



}