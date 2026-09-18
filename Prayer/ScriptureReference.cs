using System.Runtime.InteropServices.Swift;

namespace Prayer;


public class ScriptureReference
{
    public string Book { get; set; } = "";
    public int Chapter { get; set; }
    public int StartVerse { get; set; }
    public int EndVerse { get; set; }

    public override string ToString()
    {
        return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}
