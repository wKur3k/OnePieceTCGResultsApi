namespace OnePieceTCGResultsApi.Entities;

public class Deck
{
    public int Id { get; set; }
    public int LeaderId { get; set; }
    public Leader Leader { get; set; }
    public List<Note> Notes { get; set; }
    public List<Score> Scores { get; set; }
}