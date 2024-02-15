namespace OnePieceTCGResultsApi.Entities;

public class Leader
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DeckId { get; set; }
    public Deck Deck { get; set; }
    public List<Color> Colors { get; set; }
}