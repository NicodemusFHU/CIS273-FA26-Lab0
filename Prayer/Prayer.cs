namespace Prayer;

public class Prayer: AuditableRecord
{
    public string Title { get; set; } = "";
    public string? Subtitle { get; set; }
    public string Body { get; set; } = "";
    public List<ScriptureReference> ScriptureReferences { get; set; } = new();
    public Author? Author { get; set; }
    public List<Tag> Tags = new();
    public Uri? ImageUrl { get; set; }

    public override string ToString()
    {
        string result = $"{Title}";
        if(Subtitle != null)
        {
            result += $"\n{Subtitle}";
        }

        if(Author != null)
        {
            result += $"\nby {Author}";
        }

        if(ScriptureReferences.Count() > 0)
        {
            result += $"\n{string.Join(", ", ScriptureReferences)}";
        }
        if(Tags.Count > 0)
        {
            result += $"\nTags: {string.Join(", ", Tags)}";
        }

        return result;
    }
}