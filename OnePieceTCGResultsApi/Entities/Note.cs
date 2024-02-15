namespace OnePieceTCGResultsApi.Entities;

public class Note
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int DeckId { get; set; }
    public Deck Deck { get; set; }
}