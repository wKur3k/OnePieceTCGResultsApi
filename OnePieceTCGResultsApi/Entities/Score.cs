namespace OnePieceTCGResultsApi.Entities;

public class Score
{
    public int Id { get; set; }
    public bool Result { get; set; }
    public int DeckId { get; set; }
    public Deck Deck { get; set; }
}