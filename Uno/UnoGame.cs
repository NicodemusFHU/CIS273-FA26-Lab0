namespace Uno;

public class UnoGame
{
    public List<Player> Players { get; set; }
    public List<Card> DrawStack { get; set; }
    public List<Card> DiscardStack { get; set; }

    public Color CurrentColor { get; set; }
}