using System.Security.Cryptography.X509Certificates;

namespace Uno;

public class Player
{
    public string Name { get; set; } = "";

    public List<Card> Hand { get; set; } = [];

    public bool HasPlayableCard(Card card)
    {
        bool canplay = false;
        foreach (Card c in Hand)
        {
            if(Card.PlaysOn(c, card))
            {
                canplay = true;
                break;
            }
        }
        return canplay;
    }

    public Card? GetFirstPlayableCard(Card card)
    {
        Card? playable = null;
        foreach (Card c in Hand)
        {
            if(Card.PlaysOn(c, card))
            {
                playable = c;
                break;
            }
        }
        return playable;
    }

    public Color MostCommonColor()
    {
        int[] stats = [0,0,0,0,0];
        int largest = 0;
        foreach (Card c in Hand)
        {
            stats[(int)c.Color] ++;
        }
        foreach (int i in stats)
        {
            if (stats[i] > stats[largest])
            {
                largest = i;
            }
        }
        return (Color)largest;
    }
}