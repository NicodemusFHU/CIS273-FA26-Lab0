namespace Prayer;

public class Tag
{
    public string Name { get; set; } = "";
    public string? Color { get; set; }
    public string? icon { get; set; }
    public override string ToString()
    {
        return Name;
    }
}